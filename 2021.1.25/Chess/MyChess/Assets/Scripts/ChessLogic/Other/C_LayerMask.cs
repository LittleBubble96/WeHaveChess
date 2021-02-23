using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LayerMask
{
    public static int OwnDice_Layer = LayerMask.NameToLayer("OwnDice");
    public static int Floor_Layer = LayerMask.NameToLayer("Floor");
    
    //点击人物射线检测层级
    public static LayerMask PointOwnPlayerRayCheck()
    {
        return 1 << OwnDice_Layer | 1 << Floor_Layer;
    }
}
