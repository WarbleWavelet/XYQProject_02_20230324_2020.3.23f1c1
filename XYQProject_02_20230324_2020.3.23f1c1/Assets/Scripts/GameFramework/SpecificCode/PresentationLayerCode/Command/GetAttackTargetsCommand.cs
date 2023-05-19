using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：使用范围技能造成伤害的目标群体
/// 参数:作用数量
/// </summary>
public struct GetAttackTargetsCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        int num = (int)obj;
        sys.CurTarAIList.Clear();
        int tarIdx = sys.EnemyAIList.IndexOf(sys.CurAI.toAI);
       
        if (num >= sys.EnemyAIList.Count) //当前敌人总数小于技能作用目标数
        {
            num = sys.EnemyAIList.Count;
        }
        
        if (tarIdx < sys.EnemyAIList.Count)//当前指定目标索引小于数组长度
        {
            //指定敌人往后数N个目标后大于或等于作用群体目标数量                
            if (sys.EnemyAIList.Count - tarIdx >= num)
            {
                sys.CurTarAIList = sys.EnemyAIList.GetRange(tarIdx, num);
            }
            else
            {
                //分两次
                //向前取的数量
                int leftNum = num - (sys.EnemyAIList.Count - tarIdx);
                //向后取
                sys.CurTarAIList.AddRange(sys.EnemyAIList.GetRange(tarIdx, num - leftNum));
                //向前取
                sys.CurTarAIList.AddRange(sys.EnemyAIList.GetRange(tarIdx - leftNum, leftNum));
            }
        }
        else//当前选定目标正好是最后一个元素
        {
            sys.CurTarAIList = sys.EnemyAIList.GetRange(tarIdx - num, num);
        }
    }
}
