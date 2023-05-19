using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：获取当前同一阵营下的某个队友
/// 参数:
/// </summary>
public struct GetRandomCharacterCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        CharacterFightAI ai;
        if (sys.EnemyAIList.Count > 1)
        {
            ai = sys.EnemyAIList[Random.Range(0, sys.EnemyAIList.Count)];
            while (ai == sys.CurAI)
            {
                ai = sys.EnemyAIList[Random.Range(0, sys.EnemyAIList.Count)];
            }
            sys.CurAI.toAI = ai;
        }
        else
        {
            sys.CurAI.SetActCodeAndActObj(ActCode.DEFEND,new ActObj());
        }
    }
}
