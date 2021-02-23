using System;
using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using UnityEngine;
using EventType = BubbleFramework.Bubble_Event.EventType;

/// <summary>
/// 人物基类  
/// </summary>
public class C_Player : MonoBehaviour
{
    //人物属性
    [HideInInspector] public SRoleInfo roleInfo;

    //人物出战牌阵营
    [HideInInspector] public C_RoleCamp roleCamp;
    
    //人物手牌管理
    [HideInInspector] public C_RoleHand roleHand;

    public virtual void Init()
    {
        roleInfo = new SRoleInfo(100, C_CoreData.GlobalVariable.InitCoin);
        roleCamp = new C_RoleCamp();
        roleHand = new C_RoleHand();
        roleCamp.Init();
        roleHand.Init();
        // BubbleFrameEntry.GetModel<AppEventDispatcher>().AddEventListener<EventType>(EventName.EVENT_REFRESH_FLASHCARD,OnFlashCard);
    }

    public virtual void DoUpdate(float dt)
    {
        
    }

    //被攻击
    public virtual void Damage(float damage)
    {
        float cHp = roleInfo.Hp - damage;
        if (cHp <= 0) 
        {
            roleInfo.Hp = 0;
            OnDeath();
        }
        else
        {
            roleInfo.Hp = cHp;
            Injure();
        }
    }
    
    // //抽卡
    // public virtual void FlashCard(C_CardData cardData,int position)
    // {
    //     if (IsHandCard(cardData))
    //     {
    //         return;
    //     }
    //     handCards.Add(new SHandCardInfo()
    //     {
    //         Position = position,
    //         HandCard = cardData
    //     });
    // }
    

    protected virtual void OnFlashCard(EventType obj)
    {
        
    }

    //受伤
    protected virtual void Injure()
    {
        
    }

    //死亡
    protected virtual void OnDeath()
    {
        
    }

    //消耗金币
    protected virtual bool AddCoin(int coin)
    {
        if (roleInfo.Coin + coin < 0)
        {
            //金币不足
            return false;
        }
        roleInfo.Coin += coin;
        return true;
    }

    //销毁
    public virtual void OnClear()
    {
        // BubbleFrameEntry.GetModel<AppEventDispatcher>().RemoveEventListener<EventType>(EventName.EVENT_REFRESH_FLASHCARD,OnFlashCard);
    }
    
    //出战卡片
    public virtual void GoWarCard(C_CardData cardData , int[] coordinate)
    {
        if (roleHand.IsHandCard(cardData))
        {
            roleHand.RemoveHandCard(cardData);
            roleCamp.GoWarCard(cardData, coordinate);
        }
    }
    
}


public struct SRoleInfo
{
    //血量
    public float Hp;

    //最大血量
    public float MaxHp;
    
    //金币
    public int Coin;

    public SRoleInfo(int hp , int initCoin)
    {
        MaxHp = hp;
        Hp = hp;
        Coin = initCoin;
    }
}

public struct SHandCardInfo
{
    public int Position;

    public C_CardData HandCard;
}