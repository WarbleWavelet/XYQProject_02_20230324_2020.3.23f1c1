using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：清空战斗AI列表并销毁存活游戏物体
/// 参数:
/// </summary>
public struct ClearAIListAndDestoryGameObjectCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        if (sys.PlayerAI)  //销毁玩家
        {
            DestroyCharacterFightAI(sys.PlayerAI);
        }


        for (int i = 0; i < sys.EnemyAIList.Count; i++) //销毁敌人
        {
            if (sys.EnemyAIList[i])
            {
                DestroyCharacterFightAI(sys.EnemyAIList[i]);
            }
        }


        sys.EnemyAIList.Clear();
        sys.CurActAILst.Clear();
    }

    void DestroyCharacterFightAI(CharacterFightAI ai)
    {
        GameObject.Destroy(ai.gameObject); ;
    }
}
