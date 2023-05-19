using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 战斗中人物的相关UI显示，受CharacterFightAI调用
/// </summary>
public class CharacterCanvas : MonoBehaviour,IController
{
    private Slider hpSlider;
    private Text nameText;


    public void Init()
    {
        hpSlider= GetComponentInChildren<Slider>();
        nameText= GetComponentInChildren<Text>();
    }

    public void HideSlider()
    {
        hpSlider.Hide();
    }

    public void SetHPSliderValue(float value)
    {
        hpSlider.value = value;
    }

    public void SetCharacterName(string characterName)
    {
        nameText.text = characterName;
    }
}
