using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class C_CampManager
{
    private List<SCampSingle> _tempCampSingles = new List<SCampSingle>();
    
    private List<CampData> _tempCampAdditions = new List<CampData>();
    
    //获取战场里相同阵营的集合
    public List<SCampSingle> GetCampList(List<SWarCardInfo> cards)
    {
        _tempCampSingles.Clear();
        foreach (var card in cards)
        {
            CheckCampList(_tempCampSingles, card.WarCard.CardData.CampType1, card.WarCard.CardData);
            CheckCampList(_tempCampSingles, card.WarCard.CardData.CampType2, card.WarCard.CardData);
            CheckCampList(_tempCampSingles, card.WarCard.CardData.CampType3, card.WarCard.CardData);
            CheckCampList(_tempCampSingles, card.WarCard.CardData.CampType4, card.WarCard.CardData);
        }
        return _tempCampSingles;
    }

    //获取阵营加成属性
    public List<CampData> GetCampAdditions(List<SCampSingle> campSingles)
    {
        _tempCampAdditions.Clear();
        foreach (var campSingle in campSingles)
        {
            //获取所有数量大于
            var camps = BubbleFrameEntry.GetModel<GameModelManager>().GetCampDatas.FindAll((c) => c.CampType == campSingle.CampType &&
                                                                                                  campSingle.CampCount >= c.CampCount);
            var camp = camps.GetListMax();

            if (camp!=null)
            {
                _tempCampAdditions.Add(camp);
            }
        }
        return _tempCampAdditions;
    }

    //检测该卡牌的阵营
    private void CheckCampList(List<SCampSingle> campSingles , int campType , CardData cardData)
    {
        if (campType <= 0)
        {
            return;
        }
        var campSingle = campSingles.Find((c) => c.Camp.CampType == campType);
        //没有这个阵营的卡牌
        if (campSingle==null)
        {
            campSingle = new SCampSingle()
            {
                CampType = campType,
                CampCount = 1,
                CampCards = new List<CardData> {cardData}
            };
            campSingles.Add(campSingle);
        }
        //存在这个阵营的卡牌
        else
        {
            //如果不存在这个卡牌
            if (!campSingle.CampCards.Contains(cardData))
            {
                campSingle.CampCount++;
                campSingle.CampCards.Add(cardData);
            }
            else
            {
                DDebug.Log("战场上存在这个卡牌:"+cardData.Name);
            }
        }
    }
}

//阵营单条属性
public class SCampSingle
{
    //阵营类型
    public int CampType;

    //阵营数量
    public int CampCount;

    //阵营加成数据
    public CampData Camp;
    
    //阵营卡牌
    public List<CardData> CampCards;
}


