﻿using System;
using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;

public class C_GameManager : Bubble_MonoSingle<C_GameManager>
{
    private EGameState gameState;

    //游戏流程管理
    [HideInInspector]
    public C_LevelManager levelManager;

    //人物管理
    [HideInInspector] 
    public C_RoleManager roleManager;
    public void Awake()
    {
        BubbleFrameEntry.Awake();
        C_Camera.Instance.Init();
        C_Rig.ChessManager.Init();
        C_Rig.CardSystem.Init();
        C_SceneManager.Instance.Init();

        GameState = EGameState.MainMenu;
    }

    public void Update()
    {
        BubbleFrameEntry.Update(Time.deltaTime);
      
        if (GameState == EGameState.GameIn)
        {
            levelManager?.DoUpdate(Time.deltaTime);
        }
        roleManager?.DoUpdate(Time.deltaTime);
    }

    public EGameState GameState
    {
        get => gameState;
        set
        {
            if (gameState != value)
            {
                gameState = value;
                switch (value)
                {
                    case EGameState.MainMenu:
                 
                        levelManager = new C_LevelManager();
                        levelManager.Init();
                        
                        roleManager?.OnDestroy();
                        roleManager = new C_RoleManager();
                        roleManager.Init();
                        BubbleFrameEntry.GetModel<UI_Manager>().HideView(UIType.Normal);
                        BubbleFrameEntry.GetModel<UI_Manager>().Show(UI_Name.UI_C_HOME , new UI_C_HomeContent());
                        break;
                    case EGameState.GameIn:
                        BubbleFrameEntry.GetModel<UI_Manager>().HideView(UIType.Normal);
                        BubbleFrameEntry.GetModel<UI_Manager>().Show(UI_Name.UI_C_GAME, new UI_C_GameContent());
                        levelManager.StageState = EStageState.ReadyStage;
                      
                        break;
                    case EGameState.Settlement:
                        break;
                }
            }
        }
    }
}
