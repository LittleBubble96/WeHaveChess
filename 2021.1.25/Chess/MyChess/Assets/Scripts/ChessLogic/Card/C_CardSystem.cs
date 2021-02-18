using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using UnityEngine;

public partial class C_CardSystem 
{
    //游戏内卡牌 牌库
    public List<C_CardData> CardDeck = new List<C_CardData>();
    
    //所有得卡牌
    public List<C_CardData> AllCards = new List<C_CardData>();

    //所有卡片基类
    public List<CardData> CardBaseDatas;

    private int _curUId;
    
    public void Init()
    {
        _curUId = 0;
        CardBaseDatas = BubbleFrameEntry.GetModel<GameModelManager>().GetCardDatas;
        CreateNewCards();
    }

    public void DoUpdate(float dt)
    {
        
    }

    #region 接口

    //卡牌合成
    public bool SynthesisCard(int targetUId, int consume1UId , int consume2UId)
    {
        C_CardData targetCard = GetCardByDeck(targetUId);
        C_CardData consume1Card = GetCardByDeck(consume1UId);
        C_CardData consume2Card = GetCardByDeck(consume2UId);

        if (targetCard==null || consume1Card == null || consume2Card ==null || targetCard.IsMaxLevel())
        {
            return false;
        }
        //添加到卡牌合成集合里
        targetCard.SynthesisUIds.Add(consume1UId);
        targetCard.SynthesisUIds.Add(consume2UId);

        targetCard.RoleProperty.CardLevel++;
        targetCard.RefreshGameCard();
        return true;
    }


    #endregion
    
    //创建游戏得总卡牌数
    private void CreateNewCards()
    {
        for (int i = 0; i < CardBaseDatas.Count; i++)
        {
            for (int j = 0; j < C_Rig.ChessManager.chessData.CardCount; j++)
            {
                _curUId++;
                C_CardData cardData = new C_CardData(_curUId, CardBaseDatas[i].Id);
                CardDeck.Add(cardData);
                AllCards.Add(cardData);
            }
        }
    }
    
}
