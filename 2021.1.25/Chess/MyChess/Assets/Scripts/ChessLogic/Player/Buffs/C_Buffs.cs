using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Buffs
{
    //玩家
    private C_Player _role;
    
    //buffs
    private List<C_BuffBase> _buffs;
    
    public C_Buffs(C_Player role)
    {
        _role = role;
        _buffs = new List<C_BuffBase>();
    }

    //添加buff
    public void AddBuff(int id)
    {
        
    }
}
