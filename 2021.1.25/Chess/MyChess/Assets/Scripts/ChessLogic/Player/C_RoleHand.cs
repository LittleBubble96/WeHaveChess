using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RoleHand 
{
    //手牌 (0-8)
    public List<SHandCardInfo> handCards = new List<SHandCardInfo>();
    
    //占位记录 (0-8)
    public int[] HandPlaceholderRecord;

    public void Init()
    {
        HandPlaceholderRecord = new int[C_Const.HandCardCount];
    }

    //是否是手牌
    public bool IsHandCard(C_CardData card)
    {
        foreach (var handCard in handCards)
        {
            if (handCard.HandCard ==card)
            {
                return true;
            }
        }
        return false;
    }
    
    //移除手牌
    public void RemoveHandCard(C_CardData card)
    {
        if (IsHandCard(card))
        {
            SHandCardInfo handCardInfo = handCards.Find((h) => h.HandCard == card);
            handCards.Remove(handCardInfo);
        }
    }
    
    //添加手牌
    public void AddHandCard(C_CardData card,int place)
    {
        if (IsHandCard(card))
        {
            return;
        }
        
        handCards.Add(new SHandCardInfo
        {
            Position = place,
            HandCard = card
        });
        HandPlaceholderRecord[place] = 1;
    }

    //获取空得手牌位置
    public int GetEmptyPlace()
    {
        for (int i = 0; i < HandPlaceholderRecord.Length; i++)
        {
            if (HandPlaceholderRecord[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
}
