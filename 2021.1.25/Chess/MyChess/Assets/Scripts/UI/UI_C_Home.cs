using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using BubbleFramework.Bubble_UI;
using GameFramework._01_Scripts._03_Setting;
using UnityEngine;
using UnityEngine.UI;
using EventType = BubbleFramework.Bubble_Event.EventType;

public class UI_C_Home : UI_Base<UI_C_HomeContent>
{
    [Bubble_Name("阶段名字",Describe = "这个是阶段名字")]
    public Button gamePlayBtn;

    public override void Init()
    {
        base.Init();
        UiType = UIType.Normal;
        gamePlayBtn.onClick.AddListener(() =>
        {
            C_GameManager.Instance.GameState = EGameState.GameIn;
        });
    }

   
    
    


    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        //_des.text = UiBaseContent.des;
    }

    private void OnDestroy()
    {
       
    }

    public override void RefreshLanguage()
    {
        //_des.text = BubbleFrameEntry.GetModel<LanguageMgr>().GetText(0);
    }
}

public class UI_C_HomeContent :UI_BaseContent
{
    
}
