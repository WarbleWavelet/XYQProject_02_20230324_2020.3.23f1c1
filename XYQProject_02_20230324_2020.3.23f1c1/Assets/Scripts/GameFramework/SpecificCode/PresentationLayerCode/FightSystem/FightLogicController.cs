using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//*****************************************
//创建人： Trigger 
//功能说明：游戏战斗逻辑控制
//***************************************** 

/// <summary>游戏战斗逻辑控制</summary>
public class FightLogicController : MonoBehaviour, IController
{
    /// <summary>
    /// FightNavMesh是否已经激活（一般位置锁着玩家移动有所变化），
    /// 以便后面角色创建initPos
    /// </summary>
    private bool hasInit = false;
    /// <summary>因为初始不激活，其它脚本找不到FightNavMesh</summary>
    public GameObject FightNavMesh { get { return gameObject; } }



    private void OnEnable()
    {
        //TODO FindTop解决
        //this.SendCommnd<SetFightNavMeshGoCommand>(this.FightNavMesh);
        hasInit = true;
    }


    void Update()
    {

        if (hasInit)
        {
            this.SendCommnd<CreateCharactersCommand>();
            this.SendCommnd<ResetFightLogicStateCommand>();
            hasInit = false;
        }

        if (Input.GetMouseButtonDown(1))//鼠标右键
        {
            this.SendEvent<CancelUsingSkillEvent>();
        }

        this.SendCommnd<UpdateFightLogicCommand>();
    }
}
