using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData :DataModelBase
{
    //ID
    public int Id;
    
    //Name
    public string Name;

    //血量
    public float Hp;

    //伤害
    public float Damage;

    //暴击伤害
    public float CriticalDamage;
    
    //暴击率
    public float CriticalRate;
    
    //金币
    public int Coin;
    
    //最大等级
    public int MaxLevel;
    
    //阵营1
    public int CampType1;
    //阵营2
    public int CampType2;
    //阵营3
    public int CampType3;
    //阵营4
    public int CampType4;
    
    //预制路径
    public string Path;
}
