using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 鼠标右键回复血量蓝量
/// </summary>
public class RecoverHPMP : MonoBehaviour,IPointerClickHandler,IController
{
    public bool recoverHP;
    private GameObject recoverHPEffectPrefab;
    private GameObject recoverMPEffectPrefab;
    private Transform normalPlayerTrans;

    private void Start()
    {
        recoverHPEffectPrefab = ExtendResources.Get<GameObject>(ResourcesName.Prefab.RecoverHPEffect);
        recoverMPEffectPrefab = ExtendResources.Get<GameObject>(ResourcesName.Prefab.RecoverMPEffect);
        normalPlayerTrans = this.GetSystem<ISceneSystem>().PlayerNormalAI.transform;
    }

    public void RecoverHP()
    {
        this.GetModel<IPlayerDataModel>().CurHP.Value = this.GetModel<IPlayerDataModel>().MaxHP.Value;
        AudioSourceManager.Instance.PlaySound(ResourcesName.AudioClip.RecoverHP);
        GameObject go= Instantiate(recoverHPEffectPrefab,normalPlayerTrans);
        go.transform.localPosition = Vector3.zero;
    }

    public void RecoverMP()
    {
        this.GetModel<IPlayerDataModel>().CurMP.Value = this.GetModel<IPlayerDataModel>().MaxMP.Value;
        AudioSourceManager.Instance.PlaySound(ResourcesName.AudioClip.RecoverMP);
        GameObject go = Instantiate(recoverMPEffectPrefab, normalPlayerTrans);
        go.transform.localPosition = Vector3.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Right&&!this.GetSystem<ISceneSystem>().FightModeGo.activeSelf)
        {
            if (recoverHP)
            {
                RecoverHP();
            }
            else
            {
                RecoverMP();
            }
        };
    }
}
