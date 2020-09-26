﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerController(PlayerModel PlayerModel, PlayerView playerPrefab, Transform spawner)
    {
        playerModel = PlayerModel;
        playerView = GameObject.Instantiate<PlayerView>(playerPrefab, spawner.transform.position, spawner.transform.rotation);
        playerView.InitialiseController(this);
        playerView.SetViewDetails();
    }

    public PlayerView GetPlayerView()
    {
        return playerView.GetView();
    }

    public PlayerModel playerModel { get; set; }
    public PlayerView playerView { get;  }
}
    
