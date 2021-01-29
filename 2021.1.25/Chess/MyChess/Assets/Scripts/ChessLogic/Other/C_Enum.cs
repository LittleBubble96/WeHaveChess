
/// <summary>
/// 流程状态
/// </summary>
public enum EGameState
{
    None,
    MainMenu,        //主界面
    GameIn,          //游戏界面
    Settlement,      //结算界面
}

/// <summary>
/// 阶段状态
/// </summary>
public enum EStageState
{
    None,        //无
    ReadyStage,  //准备阶段
    GameStage,   //游戏阶段
    SettleStage, //结算阶段
}

/// <summary>
/// 阶段类型
/// </summary>
public enum EStageType
{
    SharedDraft = 0,    //共享选秀
    Pvp = 1,            //PVP
    Pve = 2,            //Pve
}


