using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：判断是否退出战斗
/// 参数:CharacterFightAI
/// </summary>
public struct JudgeIfExitFightCommand : ICommand
{
    public void Execute(object obj)
    {
        CharacterFightAI ai = (CharacterFightAI)obj;
        IFightSystem fightSys = this.GetSystem<IFightSystem>();
        ISceneSystem sceneSys = this.GetSystem<ISceneSystem>();
        fightSys.CurActAILst.Remove(ai);
        if (ai.isPlayer)
        {
            sceneSys.EnterOrExitFightMode(false);
        }
        else
        {
            fightSys.EnemyAIList.Remove(ai);
            if (fightSys.CurActAILst.Count > 1)
            {
                this.SendCommnd<EndCurrentTurnCommand>();
            }
            else
            {
                this.SendCommnd<ClearAIListAndDestoryGameObjectCommand>();
                sceneSys.EnterOrExitFightMode(false);
            }
        }
    }
}
