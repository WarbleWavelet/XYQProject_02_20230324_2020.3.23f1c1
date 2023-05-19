using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


//*****************************************
//创建人： Trigger 
//功能说明：人物鼠标检测
//***************************************** 


/// <summary>人物鼠标检测(Detection侦查察觉检测)[主要是选中变色]</summary>
public class CharacterMouseDetection : CharacterFightAIBehaviour
{  
    private Color initColor; 
    private Color overColor; 

    public override void Init()
    {
        base.Init();
        InitColor();
    }



    #region 系统


    private void OnMouseOver()
    {

        spriteRenderer.SetColor( overColor);
        MouseOverCursor();
    }


    private void OnMouseExit()
    {
        spriteRenderer.SetColor(initColor);
        SetCursor(CursorIconState.NORMAL);
    }


    private void OnMouseDown()
    {
        if (!IfCanClick())
        {
            return;
        }
        //
        this.SendCommnd<SetTargetAICommand>(fromAI); //当前点击的对象是Player的目标
        SetCursor(CursorIconState.NORMAL);//鼠标样式
        //
        if (this.GetSystem<ISkillSystem>().UsingSkill)
        {
            this.SendCommnd<SetCharacterActCodeCommand>( NewSkillAttackPara() );
        }
        else
        {
            this.SendCommnd<SetCharacterActCodeCommand>( NewNormalAttackPara() );
        }        
        this.SendCommnd<SetPlayerTargetAICommand>(fromAI);
        fightSystem.PlayerAI.toAI = null;
    }


    #endregion




    #region 辅助

    void InitColor()
    { 
        initColor = spriteRenderer.color;
        overColor = new Color
        (
            initColor.r * Mathf.Pow(2, 1),//n次幂 
            initColor.g * Mathf.Pow(2, 1),
            initColor.b * Mathf.Pow(2, 1)
        );
    }


    #region Attack一坨的



    void Attack(SetCharacterActCodeCommandParams para)
    {          
        this.SendCommnd<SetCharacterActCodeCommand>(para);
    }




    #region 两个结构体参数


    SetCharacterActCodeCommandParams NewNormalAttackPara()
    {
        Vector3 tarPos = fightSystem.PlayerAI.GetCurAITarPos();

        return new SetCharacterActCodeCommandParams()
        {
            actCode = ActCode.ATTACK,
            actObj = new ActObj()
            {
                atkPos = tarPos
            }
        };
    }


    SetCharacterActCodeCommandParams NewSkillAttackPara()
    {
        int skillID = this.GetSystem<ISkillSystem>().CurSkillID;
        Vector3 tarPos = fightSystem.PlayerAI.GetCurAITarPos();
        return new SetCharacterActCodeCommandParams()
        {
            actCode = ActCode.SKILL,
            actObj = new ActObj()
            {
                atkPos = tarPos,
                skillInfo = this.GetModel<ISkillDataModel>().GetSkillInfo( skillID )
            }
        };
    }
    #endregion  


    #endregion




    #region 其它

    /// <summary>鼠标在某些对象上的样式</summary>
    void MouseOverCursor()
    {
        if (IfCanClick())
        {
            if (this.GetSystem<ISkillSystem>().UsingSkill)
            {
                SetCursor(CursorIconState.SKILL);
            }
            else
            {
                SetCursor(CursorIconState.ATTACK);
            }
        }
        else
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                SetCursor(CursorIconState.FORBID);
            }
        }
    }


    void SetCursor(CursorIconState state)
    {
        this.SendEvent<SetCurrentCursorStateEvent>(state);
    }


    /// <summary>
    /// 当前人物是否可以点击
    /// </summary>
    /// <returns></returns>
    public bool IfCanClick()
    {
        bool isRightTarget = false;
        ISkillSystem sys = this.GetSystem<ISkillSystem>();
        if (sys.CurSkillID == 5)
        {
            isRightTarget = gameObject.CompareTag(Tags.PLAYER);
        }
        else
        {
            isRightTarget = gameObject.CompareTag(Tags.ENEMY);

        }
        return isRightTarget
            && !fightSystem.IsPerformingLogic
            && !EventSystem.current.IsPointerOverGameObject();
    }


    #endregion


    #endregion



}
