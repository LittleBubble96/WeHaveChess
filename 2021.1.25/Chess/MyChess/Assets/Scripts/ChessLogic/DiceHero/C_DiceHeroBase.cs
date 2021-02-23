using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DiceHeroBase : MonoBehaviour
{
    [Bubble_Name("头像")] public SpriteRenderer spriteRenderer;

    [Bubble_Name("边框")] public MeshRenderer meshRenderer;
    
    public void Init(C_CardData cardData)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>(C_Const.DiceHeroPrefabPath + cardData.CardData.Path);
    }

    public void Refresh()
    {
        
    }
}
