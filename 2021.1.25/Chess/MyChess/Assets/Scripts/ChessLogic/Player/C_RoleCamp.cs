using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RoleCamp
{
   private List<SWarCardInfo> warCards;
   //出战牌
   public List<SWarCardInfo> WarCards
   {
      get => warCards;
      set
      {
         if (warCards!=value)
         {
            warCards = value;
            RefreshCamp();
         }
      }
   }

   //阵营结构
   public List<SCampSingle> CampSingles = new List<SCampSingle>();
   
   //阵营加成数据
   public List<CampData> CampAdditions = new List<CampData>();
   
   public void Init()
   {
      warCards = new List<SWarCardInfo>();
      CampAdditions = new List<CampData>();
   }

   public void RefreshCamp()
   {
      CampSingles = C_Rig.CampManager.GetCampList(WarCards);
      CampAdditions = C_Rig.CampManager.GetCampAdditions(CampSingles);
   }

   public void GoWarCard(C_CardData card,int[] coordinate)
   {
      WarCards.Add(new SWarCardInfo()
      {
         WarCard = card,
         Coordinate = coordinate
      });
   }
   
   //是否是出战卡牌
   public bool IsWarCard(C_CardData card)
   {
      foreach (var warCard in WarCards)
      {
         if (warCard.WarCard ==card)
         {
            return true;
         }
      }
      return false;
   }
}

//出战卡牌信息
public struct SWarCardInfo
{
   public int[] Coordinate;

   public C_CardData WarCard;
}