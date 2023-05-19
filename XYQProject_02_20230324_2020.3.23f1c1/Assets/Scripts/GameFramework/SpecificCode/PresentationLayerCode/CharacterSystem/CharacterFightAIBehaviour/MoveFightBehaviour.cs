using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*****************************************
//创建人： Trigger 
//功能说明：战斗移动行为
//***************************************** 

/// <summary>战斗移动行为</summary>
public class MoveFightBehaviour : CharacterFightAIBehaviour
{

    #region 字属


    public Transform[] dieStartMovePath;
    public Transform[] dieEndMovePath;
    public int dieMovePointIdx;

    [Header("Update中的")]
    public bool isMoving;
    public bool isReturning;
    public Vector3 dieMovePoint;
    public Vector3 atkTarPos;
    #endregion




    #region 生命


   public override void Init()
    {
        base.Init();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
        // 之前debug时，此时localPosition不为Vector.zero
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.Translate(transform.position);
    }


    void Update()
    {
        if (fromAI.characterState==CharacterState.DEAD)
        {
            if (isMoving)
            {
                DieMove();
            }
            else//非死亡移动 需要设置移动状态
            {
                SetDieMoveState();
            }
            return;
        }
        //
        if (isMoving)
        {
            if (isReturning)
            {
                ReturnBehaviour();
            }
            else
            {
                MoveAttackBehaviour();
            }
        }
    }
    #endregion




    #region 辅助

    /// <summary>
    /// 返回行为
    /// </summary>
    public void ReturnBehaviour()
    {
        if (Vector3.Distance(transform.position, fromAI.initPos) <= 0.2f)
        {
            isMoving = false;
            fromAI.SetCurLookDir(Vector3.zero, true);
            characterAtrCtrl.PlayIdleAtn();
            this.SendCommnd<EndCurrentTurnCommand>();
        }
    }


    /// <summary>
    /// 移动行为(进攻移动)
    /// </summary>
    public void MoveAttackBehaviour()
    {
        if (Vector3.Distance(transform.position, atkTarPos) <= 0.2f)
        {
            isMoving = false;
            fromAI.AttackBehaviour();
        }
    }


    /// <summary>
    /// 设置攻击指令执行前的行为（目标点，是朝目标点移动还是返回初始位置）
    /// </summary>
    /// <param name="moveForward">true进攻，false返回</param>
    /// <param name="atkPos"></param>
    public void SetMoveAction(bool moveForward = false, Vector3 atkPos = default)
    {
        isMoving = true;
        if (moveForward)//进攻
        {
            MoveForward(atkPos);
        }
        else
        {
            MoveBack();
        }
    }


    /// <summary>向前移动,设置攻击的目标位置</summary>
    void MoveForward(Vector3 tarPos)
    {
        atkTarPos = tarPos;
        navMeshAgent.Translate(tarPos);
        fromAI.SetCurLookDir(tarPos);
        int moveValue = (int)MoveAtnState.ADVANCE;//调试方便看
        characterAtrCtrl.PlayMoveAtn( moveValue );
        isReturning = false;
    }


    /// <summary>向后移动</summary>
    void MoveBack()
    {
        navMeshAgent.Translate(fromAI.initPos);
        fromAI.SetCurLookDir(fromAI.initPos);
        int moveValue = (int)MoveAtnState.BACK; //调试方便看
        characterAtrCtrl.PlayMoveAtn( moveValue);
        isReturning = true;
    }




    /// <summary>
    /// 设置当前移动状态
    /// </summary>
    public void SetMovingState(bool state)
    {
        isMoving = state;
    }


    /// <summary>
    /// 释放技能造成的移动事件，平A也走这逻辑
    /// </summary>
    public void SetSkillMoveAction()
    {
        if (fromAI.toAI.characterState == CharacterState.DEAD)
        {
            this.SendCommnd<ResetCurrentAIState>(true);
        }
        else
        {
            bool moveForward = fromAI.SetSkillAttackCntAndJudgeIfMoveAction();
            SetMoveAction( moveForward, transform.position);
        }
    }

    #region Die

    /// <summary>
    /// 设置死亡移动路径
    /// </summary>
    /// <param name="startPath"></param>
    /// <param name="endPath"></param>
    public void SetDieMovePath(Transform[] startPath, Transform[] endPath)
    {
        dieStartMovePath = startPath;
        dieEndMovePath = endPath;
    }


    /// <summary>
    /// 死亡后的移动出场
    /// </summary>

    private void DieMove()
    {
        if (Vector3.Distance(transform.position, dieMovePoint) <= 0.2f)
        {
            dieMovePointIdx++;
            isMoving = false;
            if (dieMovePointIdx >= 3)
            {
                this.SendCommnd<DecreaseDieCountCommand>();
                this.SendCommnd<JudgeIfExitFightCommand>(fromAI);
                Destroy(gameObject);
            }
        }
    }


    /// <summary>
    /// 设置死亡移动的状态
    /// </summary>
    private void SetDieMoveState()
    {
        if (dieMovePointIdx < 2)//死亡移动
        {
            Vector3 movePoint;
            movePoint = dieStartMovePath[Random.Range(0, dieStartMovePath.Length)].position;
            while (movePoint == dieMovePoint)
            {
                movePoint = dieStartMovePath[Random.Range(0, dieStartMovePath.Length)].position;
            }
            dieMovePoint = movePoint;
        }
        else//即将结束死亡移动
        {
            dieMovePoint = dieEndMovePath[Random.Range(0, dieEndMovePath.Length)].position;
        }
        navMeshAgent.Translate(dieMovePoint.SetZ(transform.position.z));
        isMoving = true;
    }
    #endregion  






    #endregion


}
