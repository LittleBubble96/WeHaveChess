using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardItem : MonoBehaviour
{
    private C_CardData _cardData;

    private UI_CampItem[] campItems;

    private Text _cardName;

    private Button _selectionCardBtn;

    private Transform _root;
    
    public void Init()
    {
        campItems = GetComponentsInChildren<UI_CampItem>();
        _cardName = transform.GetChildrenComponentByNode<Text>("CardName");
        _selectionCardBtn = transform.GetChildrenComponentByNode<Button>("selectBtn");
        _root = transform.GetChildrenComponentByNode<Transform>("root");
        
        foreach (var campItem in campItems)
        {
            campItem.Init();
        }
    }

    public void SetContent(C_CardData cardData)
    {
        ShowView(true);
        _cardData = cardData;
        _cardName.text = _cardData.CardData.Name +"";
        //第一个阵营
        var type1 = BubbleFrameEntry.GetModel<GameModelManager>().GetCampTypeDatas
            .Find((c) => c.ID == cardData.CardData.CampType1);
        if (type1!=null)
        {
            campItems[0].SetContent(type1);
        }
        campItems[0].gameObject.SetActive(type1!=null);
        //第二个阵营
        var type2 = BubbleFrameEntry.GetModel<GameModelManager>().GetCampTypeDatas
            .Find((c) => c.ID == cardData.CardData.CampType2);
        if (type2!=null)
        {
            campItems[1].SetContent(type2);
        }
        campItems[1].gameObject.SetActive(type2!=null);
        //第三个阵营
        var type3 = BubbleFrameEntry.GetModel<GameModelManager>().GetCampTypeDatas
            .Find((c) => c.ID == cardData.CardData.CampType3);
        if (type3!=null)
        {
            campItems[2].SetContent(type3);
        }
        campItems[2].gameObject.SetActive(type3!=null);
        //第四个阵营
        var type4 = BubbleFrameEntry.GetModel<GameModelManager>().GetCampTypeDatas
            .Find((c) => c.ID == cardData.CardData.CampType4);
        if (type4!=null)
        {
            campItems[3].SetContent(type4);
        }
        campItems[3].gameObject.SetActive(type4!=null);
        
        //设置按钮
        _selectionCardBtn.onClick.RemoveAllListeners();
        _selectionCardBtn.onClick.AddListener(OnSelection);
    }

    private void OnSelection()
    {
        if ( C_GameManager.Instance.roleManager.OwnPlayer.OnGetCardInHandCards(_cardData))
        {
            ShowView(false);
        }
    }

    private void ShowView(bool isShow)
    {
        _root.gameObject.SetActive(isShow);
    }
}
