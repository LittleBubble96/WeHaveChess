using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Rig 
{
    //棋盘管理
    public static readonly C_ChessManager ChessManager = new C_ChessManager();
    
    //卡片系统
    public static readonly C_CardSystem CardSystem = new C_CardSystem();
    
    //阵营
    public static readonly C_CampManager CampManager = new C_CampManager();
    
    //本地缓存和 全局数据
    public static C_CoreData CoreData = new C_CoreData();
}
