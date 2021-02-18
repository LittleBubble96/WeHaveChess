using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;
using UnityEngine.UI;

public class UI_CampItem : MonoBehaviour
{
    private Image _campIcon;

    private Text _campName;
    
    public void Init()
    {
        _campIcon = transform.GetChildrenComponentByNode<Image>("icon");
        _campName = transform.GetChildrenComponentByNode<Text>("Text");
    }

    public void SetContent(CampTypeData campTypeData)
    {
        _campIcon.sprite = Resources.Load<Sprite>(C_Const.CampIconPath + campTypeData.Icon);
        _campName.text = campTypeData.Name;
    }
}
