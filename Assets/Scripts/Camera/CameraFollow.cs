using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerView player;
    void Start()
    {
        EventService.Instance.PlayerSpawn += OnPlayerSpawned;
    }

    public void OnPlayerSpawned()
    {
        Debug.Log("event listened");
        Debug.Log("Player: " + player);
        player = PlayerService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(0, 3f, 4f);
        }
        else
        {
            Debug.Log("Player is null");
        }
    }
   
}
