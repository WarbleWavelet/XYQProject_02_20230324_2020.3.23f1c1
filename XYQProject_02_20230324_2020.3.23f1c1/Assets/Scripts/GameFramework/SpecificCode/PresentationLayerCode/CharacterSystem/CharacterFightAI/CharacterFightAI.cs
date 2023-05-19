using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//*****************************************
//创建人： Trigger 
//功能说明：人物战斗AI
//***************************************** 

/// <summary>人物战斗AI</summary>
public partial class CharacterFightAI : MonoBehaviour,IController
{
    #region 字属


    #region 其它

    [Header("基础属性")]
    public int HP;
    public int curHP;
    public int MP;
    public int curMP;
    /// <summary>行动速度</summary>
    public int actRate;
    /// <summary>AOE数量</summary>
    public int AOENUM=5;
    public bool isPlayer;
    public CharacterInfo characterInfo ;


    [Header("行为")]
    public ActCode actCode;
    /// <summary>动作对象。对谁使用技能或使用物品</summary>
    public ActObj actObj;
    public CharacterState characterState;
    /// <summary>当前回合想要作用的目标人物，群攻敌人，群愈己方</summary>
    public CharacterFightAI toAI;
    /// <summary>挂载动画控制器的transform</summary>
    public Transform atrTrans;
    /// <summary>当前看向方向</summary>
    public Vector2 curLookDir;
    /// <summary>初始看向方向</summary>
    public Vector2 initLookDir;
    /// <summary>初始的
    /// ，也就是小红球，小绿球</summary>
    public Vector3 initPos;
    //TODO  位置有问题时加的变量，没用就删
    public Transform initTrans;
    /// <summary>角色身体周围的 右下 右上 左上 左下（就是被反间时晃来晃去的点）</summary>
    public Transform[] tarPosTranses;
    /// <summary>混乱时敌人的位移变化</summary>
    private ExtendTweenMethods.Tween chaosTween;
    #endregion


    [Header("功能")]
    private AttackFightBehaviour attackFightBehaviour;
    private CharacterFightValueState characterFightValueState;
    private CharacterMouseDetection characterMouseDetection;
    private DefendAndDodgeFightBehaviour defendAndDodgeFightBehaviour;
    private HitAndDieFightBehaviour hitAndDieFightBehaviour;
    private MoveFightBehaviour moveFightBehaviour;
    private UseItemAndSKillFightBehaviour useItemAndSkillFightBehaviour;
    //子节点包含的。意识记录。而是方便后来改动态赋值
    /// <summary>放边上各种Mono来访问。收束到一个地方/summary>
    public CharacterAnimatorController characterAtrCtrl;
    private CharacterCanvas characterCanvas;
    #endregion


    #region 生命

    private void Start()
    {
            
    }

    /// <summary>外部初始</summary>
    public void Init4PosTransesAnd2LookDirs()
    {
        InitFourTarPosTranses();
        InitTwoLookDir();
    }


    /// <summary>顺序问题，得单独出来，而不是放在InitComponents</summary>
    public void InitMoveFightBehaviour()
    {        
        moveFightBehaviour = gameObject.AddComponent<MoveFightBehaviour>();
        moveFightBehaviour.Init();
    }


    /// <summary>外部初始</summary>
    public void InitComponents()
    {
        // 都是在子节点的
        atrTrans = GetComponentInChildren<Animator>().transform;
        characterAtrCtrl = GetComponentInChildren<CharacterAnimatorController>();
        characterCanvas = GetComponentInChildren<CharacterCanvas>();

        characterAtrCtrl.Init();
        characterCanvas.Init();
        // 同节点的；二选一
        InitComponent_Method01();
        //InitComponent_Method02();
        // TODO Delay
       this.Delay(PlayIdleAnimation, 0.1f);
    }


    /// <summary>
    /// 执行当前阶段的逻辑（会被引用Update）
    /// </summary>
    /// <param name="ac">行为指令码</param>
    /// <param name="obj"></param>
    public void PerformLogic()
    {
        PerformCharacterState();
        PerformActCode();
    }



    private void OnDestroy()
    {
        if (chaosTween != null)
        {
            chaosTween.Pause();
            chaosTween.Kill();
        }
    }
    #endregion


    #region 辅助



    /// <summary>InitComponent()原来的写法</summary>
    void InitComponent_Method01()
    {
        characterMouseDetection = gameObject.AddComponent<CharacterMouseDetection>();
        attackFightBehaviour = gameObject.AddComponent<AttackFightBehaviour>();
        useItemAndSkillFightBehaviour = gameObject.AddComponent<UseItemAndSKillFightBehaviour>();
        defendAndDodgeFightBehaviour = gameObject.AddComponent<DefendAndDodgeFightBehaviour>();
        hitAndDieFightBehaviour = gameObject.AddComponent<HitAndDieFightBehaviour>();
        characterFightValueState = gameObject.AddComponent<CharacterFightValueState>();
        characterMouseDetection.Init();
        attackFightBehaviour.Init();
        useItemAndSkillFightBehaviour.Init();
        defendAndDodgeFightBehaviour.Init();
        hitAndDieFightBehaviour.Init();
        characterFightValueState.Init();

    }

    /// <summary>
    /// InitComponent()尝试的写法，没成功<para/>
    /// 声明，传不进gameObject
    /// </summary>
    void InitComponent_Method02()
    {
        characterMouseDetection.InitComponent<CharacterMouseDetection>(GetInstanceID());
        attackFightBehaviour.InitComponent<AttackFightBehaviour>(GetInstanceID());
        useItemAndSkillFightBehaviour.InitComponent<UseItemAndSKillFightBehaviour>(GetInstanceID());
        defendAndDodgeFightBehaviour.InitComponent<DefendAndDodgeFightBehaviour>(GetInstanceID());
        hitAndDieFightBehaviour.InitComponent<HitAndDieFightBehaviour>(GetInstanceID());
        characterFightValueState.InitComponent<CharacterFightValueState>(GetInstanceID());
    }


    /// <summary>敌人左边，玩家右边。也就是玩家是右看左，第二象限</summary>
    void InitTwoLookDir()
    {
        if (isPlayer)
        {
            initLookDir = new Vector2(-1, 1);//第二象限
        }
        else
        {
            initLookDir = new Vector2(1, -1);//第四象限
        }
        curLookDir = initLookDir;
    }


    /// <summary>
    /// 初始角色的四个点，也就是4个象限。对应Atr中的BlendTree<para />
    /// 给玩家移动向敌人。敌人移动向玩家作参考
    /// </summary>
    void InitFourTarPosTranses()
    {
        Transform tarPosTrans = transform.Find(GameObjectName.TargetPos);
        tarPosTranses = new Transform[tarPosTrans.childCount];
        for (int i = 0; i < tarPosTranses.Length; i++)
        {
            tarPosTranses[i] = tarPosTrans.GetChild(i);
        }
    }


    /// <summary>
    /// 设置当前回合的行为码和所需参数
    /// </summary>
    public void SetActCodeAndActObj(ActCode ac, ActObj obj)
    {
        actCode = ac;
        actObj = obj;
    }





    void PerformCharacterState()//初始CharacterState.NORMAL
    {
        switch (characterState)
        {
            case CharacterState.NORMAL:
                break;
            case CharacterState.REST:
                { 
                    this.SendCommnd<EndCurrentTurnCommand>(true);
                    characterState = CharacterState.NORMAL;                
                }
                break;
            case CharacterState.CHAOS:
                { 
                    if (isPlayer)
                    {
                        actCode = ActCode.DEFEND;
                    }
                    else
                    {
                        actCode = ActCode.ATTACK;
                        this.SendCommnd<GetRandomCharacterCommand>();
                        actObj.atkPos = GetCurAITarPos();
                    }                
                }
                break;
            case CharacterState.DEAD: 
            default: 
                break;
        }
    }


    void PerformActCode() //初始ActCode.ATTACK
    {
        switch (actCode)
        {
            case ActCode.ATTACK:
                moveFightBehaviour.SetMoveAction(true, actObj.atkPos);
                break;
            case ActCode.DEFEND:
                this.SendCommnd<EndCurrentTurnCommand>();
                break;
            case ActCode.SKILL:
                { 
                    if (actObj.skillInfo.skillType == SkillType.MELEE)
                    {
                        ShowMPValueChange(-actObj.skillInfo.decreaseValue1);
                        attackFightBehaviour.SetAtkCnt(3);
                        moveFightBehaviour.SetMoveAction( true, actObj.atkPos );
                        AudioSourceManager.Instance.PlaySound(ExtendPath.GetSkillPath(actObj));
                    }
                    else
                    {
                        useItemAndSkillFightBehaviour.UseItemOrUseRemoteSkillBehaviour();
                    }                
                }
                break;
            case ActCode.USEITEM:
                useItemAndSkillFightBehaviour.UseItemOrUseRemoteSkillBehaviour();
                break;
            default: break;
        }
    }

    /// <summary>
    /// 重置状态
    /// </summary>
    public void ResetState(bool ifResetActCode=false)
    {
        if (characterState == CharacterState.DEAD)
        {
            return;
        }
        //

        if (ifResetActCode)
        {
            actCode = ActCode.NONE;
        }
        //

        if (isPlayer)
        {
            this.SendCommnd<ChangeCurSkillIDCommand>(0);
        }
        //

        attackFightBehaviour.ResetAtkState();
        toAI = null;
    }


    /// <summary>
    /// 延时播放进入战斗之后的初始idle动画
    /// </summary>
    private void PlayIdleAnimation()
    {
        // transform.localPosition=Vector3.zero;//Idle时位置不对，改这里没用
        //TODO
        initPos = transform.position;
        characterAtrCtrl.PlayIdleAtn();
    }
    #endregion
}


                                     



