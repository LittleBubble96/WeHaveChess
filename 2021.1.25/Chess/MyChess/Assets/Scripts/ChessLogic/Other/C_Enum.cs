
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

public enum ECampType
{
    Demon = 1,      //恶魔
    Dragon = 2,     //龙
    Ronin = 3,      //浪人
    Glacier = 4,    //冰川
    Overlord = 5,   //霸者
    Ninja = 6,      //忍者
    Noble = 7,      //贵族
    Phantom = 8,      //幻影
    Pirate = 9,      //海盗
    Robot = 10,      //机器人
    Void = 11,      //虚空
    Wild = 12,      //野性
    Yordle = 13,      //约德尔人
    Assassin = 14,      //刺客
    Swordsman = 15,      //剑士
    Fighter = 16,      //斗士
    ElementMan = 17,      //元素使
    Protector = 18,      //守护者
    Gunman = 19,      //枪手
    Knight = 20,      //骑士
    Ranger = 21,      //游侠
    ShaperChanger = 22,      //换形师
    Magician = 23,      //法师
    
}



