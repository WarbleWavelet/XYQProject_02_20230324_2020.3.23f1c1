using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：鼠标动画
//***************************************** 
public class CursorAnimation : MonoBehaviour,IController
{
    private Texture2D[] normalTextures;
    private int cursorIndex;
    private float setCursorTimer;
    private CursorIconState iconState;
    private Texture2D[] attackTextures;
    private Texture2D[] forbidTextures;
    private Texture2D[] skillTextures;
    private Texture2D[] currentTextures;


    void Start()
    {
        normalTextures = ExtendResources.GetAll<Texture2D>(ResourcesName.Texture2D.Cursor.Normal);
        attackTextures= new Texture2D[1];
        attackTextures[0] = ExtendResources.Get<Texture2D>(ResourcesName.Texture2D.Cursor.Attack);
        forbidTextures = new Texture2D[1];
        forbidTextures[0] = ExtendResources.Get<Texture2D>(ResourcesName.Texture2D.Cursor.Forbid);
        skillTextures = ExtendResources.GetAll<Texture2D>(ResourcesName.Texture2D.Cursor.Skill);
        currentTextures = new Texture2D[9]; //做成动画效果
        currentTextures = normalTextures;
        this.RegistEvent<SetCurrentCursorStateEvent>(SetCurrentCursorState);
    }

    void Update()
    {
        if (Time.time - setCursorTimer >= 0.1f)
        {
            cursorIndex++;
            if (cursorIndex >= currentTextures.Length)
            {
                cursorIndex = 0;
            }
            Cursor.SetCursor(currentTextures[cursorIndex], Vector2.zero, CursorMode.Auto);
            setCursorTimer = Time.time;
        }
    }

    public void SetCurrentCursorState(object si)
    {
        CursorIconState setState = (CursorIconState)si;
        if (setState==iconState)
        {
            return;
        }
        else
        {
            iconState = setState;
        }
        cursorIndex = 0;
        switch (si)
        {
            case CursorIconState.NORMAL:
                currentTextures = normalTextures;
                break;
            case CursorIconState.ATTACK:
                currentTextures = attackTextures;
                break;
            case CursorIconState.FORBID:
                currentTextures = forbidTextures;
                break;
            case CursorIconState.SKILL:
                currentTextures = skillTextures;
                break;
            default:
                break;
        }
    }


}


