using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：表现层接口，负责接收输入和挡状态变化时更新游戏表现，一般继承自mono对象均处于表现层
//表现层修改系统层或者模型层里的状态需要使用Command
//可以获取系统层以及模型层里的对象来进行数据查询
//***************************************** 
public interface IController:ICanGetModle,ICanGetSystem,ICanSendCommand,ICanRegistAndUnRegistEvent,ICanSendEvent
{
    

}
