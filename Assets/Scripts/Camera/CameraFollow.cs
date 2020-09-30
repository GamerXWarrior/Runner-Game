using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerView player;
    private Vector3 initPos;
    private Quaternion initRot;
    void Start()
    {
        EventService.Instance.PlayerSpawn += OnPlayerSpawned;
        EventService.Instance.PlayerDead += OnPlayerDead;
        initPos = transform.position;
        initRot = transform.rotation;
    }

    public void OnPlayerSpawned()
    {
        player = PlayerService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(0, 2.7f, 4f);
            transform.rotation = player.transform.rotation;
        }
        else
        {
            Debug.Log("Player is null");
        }
    }

    private void OnPlayerDead()
    {
        transform.parent = null;
    }


}
