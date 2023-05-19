using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：模型层接口,负责数据的定义以及数据的一些修改方法
//模型层状态发生改变后需要调用表现层方法时，使用事件去通知表现层
//***************************************** 
public interface IModel:ICanSendEvent, ICanRegistAndUnRegistEvent
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    void Init();
}
