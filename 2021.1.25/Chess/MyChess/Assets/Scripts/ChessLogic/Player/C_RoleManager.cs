using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RoleManager
{
    private GameObject _rolesObj;

    private List<C_Player> _cPlayers;

    public C_OwnPlayer OwnPlayer;
    
    public void Init()
    {
        _cPlayers = new List<C_Player>();
        if (!_rolesObj)
        {
            _rolesObj = new GameObject("rolesObj");
            _rolesObj.transform.parent = C_GameManager.Instance.transform;
        }

        CreatePlayers();
    }

    public void DoUpdate(float dt)
    {
        foreach (var player in _cPlayers)
        {
            player.DoUpdate(dt);
        }
    }

    public void OnDestroy()
    {
        foreach (var player in _cPlayers)
        {
            player.OnClear();
        }
        _cPlayers.Clear();
    }

    //创建主角和ai
    private void CreatePlayers()
    {
        OwnPlayer = Resources.Load<C_OwnPlayer>(C_Const.OwnPlayerPrefabPath);
        OwnPlayer = Object.Instantiate(OwnPlayer, _rolesObj.transform);
        OwnPlayer.Init();
        OwnPlayer.transform.position = C_SceneManager.Instance.ownChess.playerBirth.position;
        _cPlayers.Add(OwnPlayer);
        for (int i = 0; i < C_Const.PlayerCount - 1; i++)
        {
            C_PlayerAI ai = Resources.Load<C_PlayerAI>(C_Const.AiPlayerPrefabPath);
            ai = Object.Instantiate(ai, _rolesObj.transform);
            ai.Init();
            _cPlayers.Add(ai);
        }
        
    }

}
