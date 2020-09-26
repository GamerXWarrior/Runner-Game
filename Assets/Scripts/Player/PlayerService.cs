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

    public PlayerView GetCurrentPlayer()
    {
        return player[0].GetPlayerView();
    }

    protected override void Start()
    {
        base.Start();
        SpawnPlayer(spawner, 0);
    }

    public void SpawnPlayer(Transform spawner, int playerSerial)
    {
        PlayerModel model = new PlayerModel(playerList.playerScriptableObject[0]);
        PlayerController controller = new PlayerController(model, playerView, spawner);
        player.Add(controller);
    }

}
