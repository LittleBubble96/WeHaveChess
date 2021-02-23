using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SceneManager : Bubble_MonoSingle<C_SceneManager>
{
    [Bubble_Name("主角棋盘")] 
    public C_ChessScene ownChess;
    
    [Bubble_Name("Ai1棋盘")]
    public C_ChessScene ai1Chess;
    [Bubble_Name("Ai2棋盘")]
    public C_ChessScene ai2Chess;
    [Bubble_Name("Ai3棋盘")]
    public C_ChessScene ai3Chess;
    [Bubble_Name("Ai4棋盘")]
    public C_ChessScene ai4Chess;
    [Bubble_Name("Ai5棋盘")]
    public C_ChessScene ai5Chess;
    [Bubble_Name("Ai6棋盘")]
    public C_ChessScene ai6Chess;
    [Bubble_Name("Ai7棋盘")]
    public C_ChessScene ai7Chess;

    public SMatData matData;
    public void Init()
    {
        ownChess.Init();
        // ai1Chess.Init();
        // ai2Chess.Init();
        // ai3Chess.Init();
        // ai4Chess.Init();
        // ai5Chess.Init();
        // ai6Chess.Init();
        // ai7Chess.Init();
    }

}
[System.Serializable]
public struct SMatData
{
    [Bubble_Name("高亮材质")]
    public Material highLightMat;
    [Bubble_Name("不高亮材质")]
    public Material unHighLightMat;

}
