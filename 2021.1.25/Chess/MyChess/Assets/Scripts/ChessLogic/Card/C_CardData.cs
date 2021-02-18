using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CardData
{
    //唯一标识
    public int UId;
    
    //卡片基础属性
    public CardData CardData;

    public SRoleProperty RoleProperty;
    
    public List<int> SynthesisUIds = new List<int>();

    public C_CardData(int uId, int cardId)
    {
        UId = uId;
        CardData = BubbleFrameEntry.GetModel<GameModelManager>().GetCardDatas.Find((c) => c.Id == cardId);
        
        RoleProperty = new SRoleProperty()
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
        return RoleProperty.CardLevel >= CardData.MaxLevel;
    }

    public void RefreshGameCard()
    {
        RoleProperty.Hp = CardData.Hp;
        RoleProperty.Damage = CardData.Damage;
        RoleProperty.CriticalDamage = CardData.CriticalDamage;
        RoleProperty.CriticalRate = CardData.CriticalRate;
        RoleProperty.Coin = CardData.Coin;
    }

    #endregion
  
}

public struct SRoleProperty
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
