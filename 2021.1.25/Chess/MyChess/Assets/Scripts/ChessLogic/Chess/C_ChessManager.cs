using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ChessManager
{
    public ChessData chessData;

    public void Init()
    {
        chessData = BubbleFrameEntry.GetModel<GameModelManager>().GetChessDatas.Find((c) => c.Id == 1);
    }

    public void DoUpdate(float dt)
    {
        
    }
}
