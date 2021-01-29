using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CardData
{
    //唯一标识
    public int UId;
    
    //卡片基础属性
    public CardData CardData;

    public SCardGameData CardGameData;
    
    public List<int> SynthesisUIds = new List<int>();

    public C_CardData(int uId, int cardId)
    {
        UId = uId;
        CardData = BubbleFrameEntry.GetModel<GameModelManager>().GetCardDatas.Find((c) => c.Id == cardId);
        
        CardGameData = new SCardGameData()
        {
            CardLevel = 1,
            Hp = CardData.Hp,
            Damage =  CardData.Damage,
            CriticalDamage = CardData.CriticalDamage,
            CriticalRate = CardData.CriticalRate,
            Coin = CardData.Coin
        };
    }

    #region 接口

    public bool IsMaxLevel()
    {
        return CardGameData.CardLevel >= CardData.MaxLevel;
    }

    public void RefreshGameCard()
    {
        CardGameData.Hp = CardData.Hp;
        CardGameData.Damage = CardData.Damage;
        CardGameData.CriticalDamage = CardData.CriticalDamage;
        CardGameData.CriticalRate = CardData.CriticalRate;
        CardGameData.Coin = CardData.Coin;
    }

    #endregion
  
}

public struct SCardGameData
{
    //当前等级
    public int CardLevel;

    //当前血量
    public float Hp;

    //当前伤害
    public float Damage;

    //当前暴击伤害
    public float CriticalDamage;
    
    //当前暴击率
    public float CriticalRate;
    
    //金币
    public int Coin;

}
