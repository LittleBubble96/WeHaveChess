using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using UnityEngine;
/// <summary>
/// 增删改查
/// </summary>
public partial class C_CardSystem
{
    //根据uId从所有卡里面取得牌
    public C_CardData GetCardByDeck(int uId)
    {
        C_CardData cardData = CardDeck.Find((c) => c.UId == uId);
        return cardData;
    }
    
    //根据uId从牌库里面取得牌
    public C_CardData GetCardById(int uId)
    {
        C_CardData cardData = AllCards.Find((c) => c.UId == uId);
        return cardData;
    }
    
    //随机从卡库里面抽取对应数量得牌
    public List<C_CardData> GetRandomCards(int cardCount)
    {
        //数量不足 再重新创建卡组
        if (CardDeck.Count < cardCount)
        {
            CreateNewCards();
        }
        
        List<C_CardData> result = new List<C_CardData>();
        for (int i = 0; i < cardCount; i++)
        {
            int random = Utility.Random.GetRandom(0, CardDeck.Count - 1);
            result.Add(GetCardById(random));
        }
        return result;
    }
    
    //移除卡库内卡牌 根据卡牌
    public void RemoveCardInDeck(C_CardData card)
    {
        if (CardDeck.Contains(card))
        {
            CardDeck.Remove(card);
        }
    }
    
    //移除卡库内卡牌 根据uId
    public void RemoveCardInDeck(int uId)
    {
        C_CardData cardData = GetCardById(uId);
        if (cardData!=null)
        {
            RemoveCardInDeck(cardData);
        }
    }
}
