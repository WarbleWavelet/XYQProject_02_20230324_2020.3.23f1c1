using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：系统层接口,帮助表现层承担一部分逻辑（多个表现层共享的逻辑） 
//系统层状态发生改变后需要调用表现层方法时，使用事件去通知表现层
//***************************************** 
public interface ISystem:ICanGetModle,ICanSendEvent,ICanRegistAndUnRegistEvent
{
    void Init();
}
