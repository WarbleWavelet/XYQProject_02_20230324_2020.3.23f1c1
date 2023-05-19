using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//*****************************************
//创建人： Trigger 
//功能说明：事件
//***************************************** 
public class EventRegistration:IEventRegistration
{
    public Action<object> OnEvent = obj => { };
}
