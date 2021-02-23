using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//本地缓存 和全局数据
public class C_CoreData
{
    public static TableGlobalVariable GlobalVariable = BubbleFrameEntry.GetModel<GameModelManager>().GetTableGlobalVariables[0];
}
