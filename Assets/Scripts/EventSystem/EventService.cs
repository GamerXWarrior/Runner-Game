using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : MonoGenericSingleton<EventService>
{
    public event Action PlayerSpawn;
    public event Action TakeDamage;
    public event Action PlayerDead;

    public void OnPlayerSpawn()
    {
        PlayerSpawn?.Invoke();
    }
    
    public void OnPlayerDead()
    {
        PlayerDead?.Invoke();
    }

    public void PlayerDamage()
    {
        TakeDamage?.Invoke();
    }
}
