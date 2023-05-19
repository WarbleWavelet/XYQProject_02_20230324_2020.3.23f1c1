using UnityEngine;
/// <summary>
/// 创建人：Trigger <para/>
/// 命令名称：随机敌人AI的行动命令    <para/>
/// 参数:                   <para/>
/// </summary>
public struct RandomEnemyActCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        CharacterFightAI fromAI = sys.CurAI;//敌人
        fromAI.toAI = sys.PlayerAI;//敌人的目标是玩家
        Vector3 tarPos= fromAI.GetCurAITarPos(); 
        //
        ActCode actCode = (ActCode)Random.Range(0,4);
        ActObj actObj = new ActObj();
        //
        switch (actCode)
        {
            case ActCode.ATTACK:
                actObj.atkPos = tarPos;
                break;
            case ActCode.DEFEND:
                break;
            case ActCode.SKILL:
                { 
                    int skillID = Random.Range(1, 6);
                    switch (skillID)
                    {
                        case 1:
                            actObj.atkPos = tarPos;
                            break;
                        case 2:
                        case 4:
                            skillID = 3;
                            break;
                        case 5:
                            this.SendCommnd<GetRandomCharacterCommand>();
                            break;
                        default: break;
                    }               
                    actObj.skillInfo = this.GetModel<ISkillDataModel>().GetSkillInfo(skillID);                
                }
                break;
            case ActCode.USEITEM:
                actObj.itemID = 0;
                break;
            default: break;
        }
        fromAI.SetActCodeAndActObj(actCode, actObj);
    }
}