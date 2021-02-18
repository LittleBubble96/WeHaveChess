using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using BubbleFramework.Bubble_UI;
using GameFramework._01_Scripts._03_Setting;
using UnityEngine;
using UnityEngine.UI;
using EventType = BubbleFramework.Bubble_Event.EventType;

public class UI_C_Game : UI_Base<UI_C_GameContent>
{
    [Bubble_Name("阶段名字",Describe = "这个是阶段名字")]
    public Text curStageName;
    [Bubble_Name("小阶段名字",Describe = "这个是阶段名字")]
    public Text curSectionName;
    [Bubble_Name("小阶段时间",Describe = "这个是阶段时间")]
    public Text curSectionTime;
    [Bubble_Name("进度条",Describe = "这个是进度条")]
    public RectTransform stageFill;

    //抽卡根节点
    private Transform _flashRoot;
    //抽卡得卡片
    private UI_CardItem[] _cardItems;
    
    private Vector2 _fillSize;
    public override void Init()
    {
        base.Init();
        UiType = UIType.Normal;
        _flashRoot = transform.GetChildrenComponentByNode<Transform>("flashRoot");
        _cardItems = _flashRoot.GetComponentsInChildren<UI_CardItem>();
        
        _fillSize = stageFill.sizeDelta;

        foreach (var card in _cardItems)
        {
            card.Init();
        }
        
        BubbleFrameEntry.GetModel<AppEventDispatcher>().AddEventListener<EventType>(EventName.EVENT_REFRESH_STAGENAME,OnRefreshStageName);
        BubbleFrameEntry.GetModel<AppEventDispatcher>().AddEventListener<EventType>(EventName.EVENT_REFRESH_STAGETIME,OnRefreshStageTime);
        BubbleFrameEntry.GetModel<AppEventDispatcher>().AddEventListener<EventType>(EventName.EVENT_REFRESH_FLASHCARD,OnFlashCard);
    }

    

    //刷新阶段名
    private void OnRefreshStageName(EventType obj)
    {
        if (obj is MultiEvent<string, string> item)
        {
            curSectionName.text = item.Value;
            curStageName.text = item.Value1;
        }

    }
    
    //刷新阶段时间
    private void OnRefreshStageTime(EventType obj)
    {
        if (obj is MultiEvent<float,float> item)
        {
            float maxTime = item.Value1;
            int h = (int)item.Value / 60 / 60;
            int m = (int) item.Value % (3600) / 60;
            int s = (int) item.Value % 60;
            string hStr = h < 10 ? "0" + h : h + "";
            string mStr = m < 10 ? "0" + m : m + "";
            string sStr = s < 10 ? "0" + s : s + "";
            curSectionTime.text = hStr + ":" + mStr + ":" + sStr;

            stageFill.sizeDelta = new Vector2(_fillSize.x * item.Value / maxTime, _fillSize.y);
        }
    }
    
    //抽卡
    private void OnFlashCard(EventType obj)
    {
        if (obj is MultiEvent<List<C_CardData>> item)
        {
            for (int i = 0; i < _cardItems.Length; i++)
            {
                _cardItems[i].SetContent(item.Value[i]);
            }
        }
    }


    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        //_des.text = UiBaseContent.des;
    }

    private void OnDestroy()
    {
        BubbleFrameEntry.GetModel<AppEventDispatcher>().RemoveEventListener<EventType>(EventName.EVENT_REFRESH_STAGENAME,OnRefreshStageName);
        BubbleFrameEntry.GetModel<AppEventDispatcher>().RemoveEventListener<EventType>(EventName.EVENT_REFRESH_STAGETIME,OnRefreshStageTime);
        BubbleFrameEntry.GetModel<AppEventDispatcher>().RemoveEventListener<EventType>(EventName.EVENT_REFRESH_FLASHCARD,OnFlashCard);
    }

    public override void RefreshLanguage()
    {
        //_des.text = BubbleFrameEntry.GetModel<LanguageMgr>().GetText(0);
    }
}

public class UI_C_GameContent :UI_BaseContent
{

    public UI_C_GameContent()
    {
        
    }
}
