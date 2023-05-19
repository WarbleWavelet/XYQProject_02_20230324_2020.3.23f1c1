using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>检测玩家是否点击到不可走区域</summary>
public class NotWalkableArea : MonoBehaviour,IController
{
    private void OnMouseDown()
    {
        this.SendCommnd<SetWillStoppingStateCommand>();
    }
}
