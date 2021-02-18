using System;
using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using UnityEngine;

public class C_LevelManager
{
    //当前小阶段
    public SSectionInfo CurSection;

    //关卡数据
    public List<StageData> StageDatas;

    //当前阶段
    public StageData StageData;

    //当前阶段数
    public int CurStageCount;

    //当前小阶段数
    public int CurSectionCount;
    
    //当前阶段行为（共享选秀，Pve，Pvp）
    private C_BattleMoBase battleMoBase;
    
    //阶段状态
    private EStageState stageState;
    
    //计时器
    private float timer;

    public void Init()
    {
        StageDatas = BubbleFrameEntry.GetModel<GameModelManager>().GetStageDatas;
        CurSection = new SSectionInfo();
        
        CurStageCount = 1;
        CurSectionCount = 1;

        CheckStage();

        StageState = EStageState.ReadyStage;
    }

    public void DoUpdate(float dt)
    {
        if (StageState == EStageState.ReadyStage)
        {
            timer -= dt;
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGENAME,"准备阶段",StageData.Name);
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGETIME,timer,C_Const.StageReadyTime);
            if (timer < 0)
            {
                StageState = EStageState.GameStage;
            }
        }
        else if (StageState == EStageState.GameStage)
        {
            timer -= dt;
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGENAME,"战斗阶段",StageData.Name);
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGETIME,timer,CurSection.Duration);
            battleMoBase?.DoUpdate(dt);
            if (timer < 0)
            {
                StageState = EStageState.SettleStage;
            }
        }
        else if (StageState == EStageState.SettleStage)
        {
            timer -= dt;
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGENAME,"结算阶段",StageData.Name);
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_STAGETIME,timer,C_Const.StageSettleTime);
            if (timer < 0)
            {
                StageState = EStageState.ReadyStage;
            }
        }
    }

    public EStageState StageState
    {
        get => stageState;
        set
        {
            if (stageState!=value)
            {
                stageState = value;
                switch (value)
                {
                    case EStageState.None:
                        break;
                    case EStageState.ReadyStage:
                        CheckStage();
                        timer = C_Const.StageReadyTime;
                        break;
                    case EStageState.GameStage:
                        timer = CurSection.Duration;
                        break;
                    case EStageState.SettleStage:
                        timer = C_Const.StageSettleTime;
                        CurSectionCount++;
                        break;
                }
            }
        }
    }

    //检测小阶段
    private void CheckStage()
    {
        //超出本阶段数
        if (StageData!=null && CurSectionCount > StageData.FlowCount)
        {
            CurStageCount++;
            CurSectionCount = 1;
        }
        //设置小阶段
        StageData = StageDatas.Find((s) => s.ID == CurStageCount) ?? StageDatas[StageDatas.Count - 1];
        switch (CurSectionCount)
        {
            case 1:
                CurSection.FlowType = StageData.FlowType1;
                CurSection.Param1 = StageData.Param1_1;
                CurSection.Param2 = StageData.Param1_2;
                CurSection.Param3 = StageData.Param1_3;
                CurSection.Param4 = StageData.Param1_4;
                CurSection.Duration = StageData.Duration1;
                CurSection.Coin = StageData.CoinBase1;
                break;
            case 2:
                CurSection.FlowType = StageData.FlowType2;
                CurSection.Param1 = StageData.Param2_1;
                CurSection.Param2 = StageData.Param2_2;
                CurSection.Param3 = StageData.Param2_3;
                CurSection.Param4 = StageData.Param2_4;
                CurSection.Duration = StageData.Duration2;
                CurSection.Coin = StageData.CoinBase2;
                break;
            case 3:
                CurSection.FlowType = StageData.FlowType3;
                CurSection.Param1 = StageData.Param3_1;
                CurSection.Param2 = StageData.Param3_2;
                CurSection.Param3 = StageData.Param3_3;
                CurSection.Param4 = StageData.Param3_4;
                CurSection.Duration = StageData.Duration3;
                CurSection.Coin = StageData.CoinBase3;
                break;
            case 4:
                CurSection.FlowType = StageData.FlowType4;
                CurSection.Param1 = StageData.Param4_1;
                CurSection.Param2 = StageData.Param4_2;
                CurSection.Param3 = StageData.Param4_3;
                CurSection.Param4 = StageData.Param4_4;
                CurSection.Duration = StageData.Duration4;
                CurSection.Coin = StageData.CoinBase4;
                break;
            case 5:
                CurSection.FlowType = StageData.FlowType5;
                CurSection.Param1 = StageData.Param5_1;
                CurSection.Param2 = StageData.Param5_2;
                CurSection.Param3 = StageData.Param5_3;
                CurSection.Param4 = StageData.Param5_4;
                CurSection.Duration = StageData.Duration5;
                CurSection.Coin = StageData.CoinBase5;
                break;
            case 6:
                CurSection.FlowType = StageData.FlowType6;
                CurSection.Param1 = StageData.Param6_1;
                CurSection.Param2 = StageData.Param6_2;
                CurSection.Param3 = StageData.Param6_3;
                CurSection.Param4 = StageData.Param6_4;
                CurSection.Duration = StageData.Duration6;
                CurSection.Coin = StageData.CoinBase6;
                break;
            case 7:
                CurSection.FlowType = StageData.FlowType7;
                CurSection.Param1 = StageData.Param7_1;
                CurSection.Param2 = StageData.Param7_2;
                CurSection.Param3 = StageData.Param7_3;
                CurSection.Param4 = StageData.Param7_4;
                CurSection.Duration = StageData.Duration7;
                CurSection.Coin = StageData.CoinBase7;
                break;
        }
        
        //初始化阶段行为
        switch ((EStageType)CurSection.FlowType)
        {
            case EStageType.SharedDraft:
                battleMoBase = new C_SharedDraftBattle();
                break;
            case EStageType.Pvp:
                battleMoBase = new C_PvpBattle();
                break;
            case EStageType.Pve:
                battleMoBase = new C_PveBattle();
                break;
        }
        battleMoBase.Init(CurSection);
        
        CheckFlashCard();
    }

    //抽卡    pve 和 pvp
    private void CheckFlashCard()
    {
        bool canFlash = (EStageType) CurSection.FlowType == EStageType.Pve ||
                        (EStageType) CurSection.FlowType == EStageType.Pvp;
        if (canFlash)
        {
            BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_REFRESH_FLASHCARD,C_Rig.CardSystem.GetRandomCards(5));
        }
    }

}


//小阶段
public struct SSectionInfo
{
    public int FlowType;

    public float Duration;

    public float Coin;

    public int[] Param1;

    public float Param2;

    public float Param3;

    public Vector2[] Param4;

}
