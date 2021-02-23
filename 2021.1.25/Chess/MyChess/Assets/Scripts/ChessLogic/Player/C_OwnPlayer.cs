using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class C_OwnPlayer : C_Player
{
    public override void Init()
    {
        base.Init();
        inputInfo = new SInputInfo();
    }

    #region 接口

    public bool OnGetCardInHandCards(C_CardData card)
    {
        int emptyPlace = roleHand.GetEmptyPlace();
        if (emptyPlace == -1) 
        {
            //手牌数量过多
            DDebug.Log("手牌过多");
            return false;
        }

        if (!AddCoin(-card.RoleProperty.Coin))
        {
            //金币不足
            return false;
        }
        C_Rig.CardSystem.RemoveCardInDeck(card);
        roleHand.AddHandCard(card,emptyPlace);
        C_SceneManager.Instance.ownChess.Create(card,emptyPlace);
        return true;
    }

  

    #endregion

    public override void DoUpdate(float dt)
    {
        base.DoUpdate(dt);
        bool canControl = C_GameManager.Instance.GameState == EGameState.GameIn;
        canControl &= ((EStageType) C_GameManager.Instance.levelManager.CurSection.FlowType == EStageType.Pve ||
                       (EStageType) C_GameManager.Instance.levelManager.CurSection.FlowType == EStageType.Pvp);
        canControl &= C_GameManager.Instance.levelManager.StageState == EStageState.ReadyStage;
        if (canControl)
        {
            //操作
            UpdateInputCtrl();
        }
    }

    #region 鼠标控制逻辑

    private SInputInfo inputInfo;

    private void UpdateInputCtrl()
    {
        //鼠标左键按下  英雄跟随
        if (Input.GetMouseButtonDown(C_Const.LeftMouse))
        {
            DDebug.Log("按下");
            Ray ray = C_Camera.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out var hit , 100, 1<<C_LayerMask.OwnDice_Layer))
            {
                var dice = hit.collider.gameObject.GetComponentInChildren<C_DiceHeroBase>();
                if (dice)
                {
                    inputInfo.CtrlDice = dice;
                }
            }
        }
        //鼠标左键一直按下 跟随
        if (Input.GetMouseButton(C_Const.LeftMouse))
        {
            if (!inputInfo.CtrlDice)
            {
                return;
            }
            DDebug.Log("一直按下");
            Ray ray = C_Camera.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out var hit , 100, 1<<C_LayerMask.Floor_Layer))
            {
                var handPos = C_SceneManager.Instance.ownChess.GetHandCardPointByPos(hit.point);
                if (handPos!=null)
                {
                    inputInfo.CtrlDice.transform.position = hit.point + Vector3.up * 0.5f;
                }
                //inputInfo.CtrlDice = dice;
            }
        }
    }

    #endregion
   
}

//鼠标信息
public struct SInputInfo
{
    //控制得英雄
    public C_DiceHeroBase CtrlDice;
    
    //TODO
} 
