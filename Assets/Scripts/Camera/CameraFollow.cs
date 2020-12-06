using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private PlayerView player;
    private Vector3 initPos;
    private Quaternion initRot;
    public CinemachineVirtualCamera cineCam;

    private void Start()
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
            //cineCam.m_LookAt = player.transform;
            cineCam.m_Follow = player.transform.GetChild(0).transform;
            Debug.Log(cineCam.m_Follow.name);
            //cineCam.transform.position = new Vector3(0, 5f, 4f);
            //transform.position = player.transform.position + new Vector3(0, 5f, 4f);
            transform.rotation = player.transform.rotation;
        }
        else
        {
            Debug.Log("Player is null");
        }
    }

    public void SwipeLeft()
    {
        player.SwipeLeft();
    }

    public void SwipeRight()
    {
        player.SwipeRight();
    }

    public void Slide()
    {
        player.Slide();
    }

    public void Jump()
    {
        player.Jump();
    }

    private void OnPlayerDead()
    {
        transform.parent = null;
    }
}