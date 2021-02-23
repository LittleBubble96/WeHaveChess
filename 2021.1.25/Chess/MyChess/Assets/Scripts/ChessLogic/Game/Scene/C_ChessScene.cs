using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class C_ChessScene : MonoBehaviour
{
    [Bubble_Name("人物出生位置")] 
    public Transform playerBirth;

    [Bubble_Name("装备位置数组")] 
    public Transform[] equipPoints;
    
    public SHexagon hexagon;
    
    public SHandCardPointInfo[] cardPointInfos;
    
    public void Init()
    {
        
    }

   

    #region 接口
    //出生英雄
    public C_DiceHeroBase Create(C_CardData card,int place)
    {
        C_DiceHeroBase dice = Resources.Load<C_DiceHeroBase>(C_Const.CardPrefabPath);
        dice = Instantiate(dice);
        dice.Init(card);
        dice.transform.position = cardPointInfos[place].pointRect.center;
        return null;
    }
    
    //根据位置获取手牌
    public SHandCardPointInfo GetHandCardPointByPos(Vector3 pos)
    {
        SHandCardPointInfo cardInfo = null;
        foreach (var cardPointInfo in cardPointInfos)
        {
            if (cardPointInfo.pointRect.IsInside(pos))
            {
                cardInfo = cardPointInfo;
                cardPointInfo.HighLightRenderer();
            }
            else
            {
                cardPointInfo.UnHighLightRenderer();
            }
        }
        return cardInfo;
    }

    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        foreach (var cardPointInfo in cardPointInfos)
        {
            cardPointInfo.OnDraw();
        }
        hexagon.OnDraw();
    }
#endif
  
}

[System.Serializable]
//手牌位置信息
public class SHandCardPointInfo
{
    //卡牌
    [HideInInspector]
    public C_CardData card;
    
    //位置
    public SRect pointRect;

    //高亮预制
    [Bubble_Name("高亮预制")] 
    public MeshRenderer highLight;

    public bool IsHighLight { get; set; }

   
    
    //高亮
    public void HighLightRenderer()
    {
        if (IsHighLight)
        {
            return;
        }

        highLight.material = C_SceneManager.Instance.matData.highLightMat;
        IsHighLight = true;
    }
    
    //取消高亮 
    public void UnHighLightRenderer()
    {
        if (!IsHighLight)
        {
            return;
        }
        highLight.material = C_SceneManager.Instance.matData.unHighLightMat;
        IsHighLight = false;
    }

#if UNITY_EDITOR

    public void OnDraw()
    {
        pointRect.OnDraw();
    }
#endif

}

[System.Serializable]
public class SHexagon
{
    //中心
    public Vector3 center;
    
    //横向距离
    public float hor = 1.44f;
    
    //纵向距离1
    public float ver1 = 0.84f;
    
    //纵向距离2
    public float ver2 = 1.7f;
    

    //判断是否再六边形里
    public bool IsInside(Vector3 xZPos)
    {
        Vector3 up = center + Vector3.forward * ver2;
        Vector3 upRight = center + Vector3.forward * ver1 + Vector3.right * hor;
        Vector3 downRight = center - Vector3.forward * ver1 + Vector3.right * hor;
        Vector3 down = center - Vector3.forward * ver2;
        Vector3 downLeft = center - Vector3.forward * ver1 - Vector3.right * hor;
        Vector3 upLeft = center + Vector3.forward * ver1 - Vector3.right * hor;
        return Cross(up, upRight, xZPos) >= 0 &&
               Cross(upRight, downRight, xZPos) >= 0 &&
               Cross(downRight, down, xZPos) >= 0 &&
               Cross(down, downLeft, xZPos) <= 0 &&
               Cross(downLeft, upLeft, xZPos) <= 0 &&
               Cross(upLeft, up, xZPos) <= 0;
    }

    private float Cross(Vector3 from , Vector3 to , Vector3 pos)
    {
        pos = new Vector3(pos.x, from.y, pos.z);
        Vector3 dir = to - from;
        Vector3 end = pos - from;
        return Vector3.Cross(dir, end).y;
    }

#if UNITY_EDITOR
    public void OnDraw()
    {
        Vector3 up = center + Vector3.forward * ver2;
        Vector3 upRight = center + Vector3.forward * ver1 + Vector3.right * hor;
        Vector3 downRight = center - Vector3.forward * ver1 + Vector3.right * hor;
        Vector3 down = center - Vector3.forward * ver2;
        Vector3 downLeft = center - Vector3.forward * ver1 - Vector3.right * hor;
        Vector3 upLeft = center + Vector3.forward * ver1 - Vector3.right * hor;
        
        Gizmos.color = Color.white;

        Gizmos.DrawLine(up, upRight);
        Gizmos.DrawLine(upRight, downRight);
        Gizmos.DrawLine(downRight, down);
        Gizmos.DrawLine(down, downLeft);
        Gizmos.DrawLine(downLeft, upLeft);
        Gizmos.DrawLine(upLeft, up);
    }
#endif
 
}

[System.Serializable]
public class SRect
{
    [Bubble_Name("中心")]
    public Vector3 center;
    [Space]
    [Space]
    [Space]
    [Bubble_Name("长")] public float width;

    [Bubble_Name("宽")] public float height;
    
    //是否再矩形内
    public bool IsInside(Vector3 pos)
    {
        return pos.x <= center.x + width * 0.5f &&
               pos.x >= center.x - width * 0.5f &&
               pos.y <= center.y + height * 0.5f &&
               pos.y >= center.y - height * 0.5f;
    }

#if UNITY_EDITOR

    public void OnDraw()
    {
        Vector3 upRight = center + Vector3.right * width * 0.5f + Vector3.forward * height * 0.5f;
        Vector3 downRight = center + Vector3.right * width * 0.5f - Vector3.forward * height * 0.5f;
        Vector3 downLeft = center - Vector3.right * width * 0.5f - Vector3.forward * height * 0.5f;
        Vector3 upLeft = center - Vector3.right * width * 0.5f + Vector3.forward * height * 0.5f;
        Gizmos.DrawLine(upRight, downRight);
        Gizmos.DrawLine(downRight, downLeft);
        Gizmos.DrawLine(downLeft, upLeft);
        Gizmos.DrawLine(upLeft, upRight);
    }
#endif
}
