using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public PlayerModel(PlayerScriptableObject player)
    {
        MovingSpeed = player.speed;
        Gravity = player.garvity;
        Health = player.health;
    }

    public float MovingSpeed { get; }
    public float Gravity { get; }
    public float Health { get; }
}
