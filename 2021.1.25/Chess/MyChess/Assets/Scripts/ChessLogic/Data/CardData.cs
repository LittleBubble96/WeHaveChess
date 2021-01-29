using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData :DataModelBase
{
    //ID
    public int Id;
    
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
}
