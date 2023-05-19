using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//*****************************************
//创建人： Trigger 
//功能说明：非战斗状态下的寻路
//*****************************************        、


/// <summary>非战斗状态下的寻路</summary>
public class CharacterNormalAI : MonoBehaviour
{


    #region 字属

    public bool willStopping;
    public bool followMouse;
    private NavMeshAgent navMeshAgent;

    private CharacterAnimatorController characterAtrCtrl;
    private float createEffectTimer;
    /// <summary>实例鼠标特效的父节点，不然一堆太乱了</summary>
    private Transform clickEffectsTrans;
    private GameObject clickEffectGo;
    private float followMouseTimer;
    private int clickCnt;
    /// <summary>鼠标点击的地方，玩家要去的地方</summary>
    private Vector3 tarPos;
    [Header("我加的，不用可删")]
    /// <summary>人物在绿球,战斗时相机和人物的位置才正确，所以先存下绿球的位置</summary>
    public Vector3 initPos;
    /// <summary>进入战斗前的位置，用来退出战斗后复位</summary>
    public Vector3 curPos;
    #endregion



    #region 生命



    private void Awake()
    {
        Init();

    }
                
    private void OnEnable()
    {
        tarPos = transform.position;
    }

    void Init()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        characterAtrCtrl = GetComponentInChildren<CharacterAnimatorController>();

        clickEffectGo = Resources.Load<GameObject>(ResourcesName.Prefab.CursorEffect);
        //
        characterAtrCtrl.Init();
        //
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        tarPos=transform.position;
        navMeshAgent.updatePosition = false;
        //
        clickEffectsTrans = transform.FindTop( GameObjectName.ClickEffects );
    }

    void Update()
    {
        characterAtrCtrl.PlayLocomotionAtn( 
            transform.position, 
            navMeshAgent.nextPosition,
            tarPos
        );
        SetNavAgentState();
        if (Input.GetMouseButtonDown(0))
        {
            clickCnt++;
            followMouse = false;
            ClickMouse();
        }
        GetNotWalkableAreaMovePoint();
        DoubleClickMouse();
        transform.position = navMeshAgent.nextPosition;
    }
    #endregion



    #region 辅助


    private void SetNavAgentState()
    {
        navMeshAgent.isStopped = !characterAtrCtrl.isMoving;
    }



    private void GetNotWalkableAreaMovePoint()
    {
        if (willStopping)
        {

            Ray2D ray = new Ray2D(transform.position, tarPos - transform.position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                tarPos = hit.point;
                tarPos -= 0.1f * (tarPos - transform.position);
            }
            navMeshAgent.Translate(tarPos.SetZ(transform.position.z));
        }
    }

    /// <summary>单击人物追过去</summary>
    private void ClickMouse()
    {
        tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        navMeshAgent.Translate(tarPos.SetZ(transform.position.z));
        //
        if (Time.time - createEffectTimer >= 0.05f)
        {
            createEffectTimer = Time.time;
            GameObject go = Instantiate(clickEffectGo, tarPos, Quaternion.identity);
            go.SetParent(clickEffectsTrans);
        }
    }


    /// <summary>双击人物跟随鼠标</summary>
    private void DoubleClickMouse()
    {
        if (followMouse)//开启开关，人物跟随鼠标移动
        {
            ClickMouse();
        }
        else
        {
            if (Time.time-followMouseTimer>=0.4f)
            {
                //已超出规定时间，重新计时
                followMouseTimer = Time.time;
                clickCnt = 0;
            }
            else
            {
                //在时间间隔内
                if (clickCnt>1)
                {
                    //双击
                    followMouse = true;
                }
            }
        }
    }
    #endregion


    public void EnterFight(bool _bool)
    {
        if (_bool)
        {
            curPos = transform.position;
            transform.position = initPos;
        }
        else
        {
            transform.position = curPos;
        }

    }
                     
}
