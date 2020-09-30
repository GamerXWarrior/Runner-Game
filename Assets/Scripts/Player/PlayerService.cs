using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoGenericSingleton<PlayerService>
{
    public PlayerView playerView;
    public PlayerScriptableObjectList playerList;
    public Transform spawner;
    private List<PlayerController> player = new List<PlayerController>();

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        EventService.Instance.TakeDamage += TakeDamage;
        base.Start();
    }
    public PlayerView GetCurrentPlayer()
    {
        return player[0].GetPlayerView();
    }

    public void TakeDamage()
    {
        player[0].TakeDamage();
    }

    public void StartGame()
    {
        SpawnPlayer(spawner, 0);
    }

    public float GetPlayerSpawnPos()
    {
        return player[0].GetPlayerStartPos();
    }
    public float GetPlayerFinishPos()
    {
        return player[0].GetPlayerEndPos();
    }

    public void SpawnPlayer(Transform spawner, int playerSerial)
    {
        PlayerModel model = new PlayerModel(playerList.playerScriptableObject[0]);
        PlayerController controller = new PlayerController(model, playerView, spawner);
        player.Add(controller);
    }

}
