using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : MonoGenericSingleton<EventService>
{
    public event Action PlayerSpawn;

    public void OnPlayerSpawn()
    {
        Debug.Log("event fired");
        PlayerSpawn?.Invoke();
    }
}
