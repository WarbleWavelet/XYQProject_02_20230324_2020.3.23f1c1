using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//*****************************************
//创建人： Trigger 
//功能说明：人物AI行为基类
//***************************************** 


/// <summary>人物AI行为基类[改了，CharacterAnimatorController不放在同1个节点]</summary>
//[RequireComponent(typeof(CharacterAnimatorController))]
//[RequireComponent(typeof(CharacterFightAI))]
//[RequireComponent(typeof(NavMeshAgent))]
public class CharacterFightAIBehaviour : MonoBehaviour,IController
{

    [SerializeField] protected CharacterAnimatorController characterAtrCtrl;
    [SerializeField] protected CharacterFightAI fromAI;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected IFightSystem fightSystem;



    /// <summary>虚的选择性重写</summary>
    public virtual void Init()
    {        
        fightSystem = this.GetSystem<IFightSystem>();      
        navMeshAgent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        characterAtrCtrl = GetComponentInChildren<CharacterAnimatorController>();//写死了在子节点上
        //
        fromAI = GetComponent<CharacterFightAI>(); 
    }
}
