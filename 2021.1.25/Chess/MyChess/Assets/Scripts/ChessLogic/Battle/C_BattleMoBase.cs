using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BattleMoBase
{
    //阶段参数
    protected SSectionInfo SectionInfo;
    
    public void Init(SSectionInfo sectionInfo)
    {
        SectionInfo = sectionInfo;
    }

    public void DoUpdate(float dt)
    {
        
    }
}
