using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public float nextPos = -55f;
    public int noOfGround = 3;
    private float X;
    private float Y;
    private float Z;
    public List<GameObject> obstacles;
    public List<GameObject> collectables;

    public void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.GetComponent<PlayerView>())
        {
            X = transform.position.x;
            Y = transform.position.y;
            Z = transform.position.z;
            gameObject.transform.position = new Vector3(X, Y, Z + (noOfGround * nextPos));
            ActivateAllCollectables();
            ActivateAllObstacles();
        }
    }

    public void ActivateAllObstacles()
    {
        foreach (GameObject obj in obstacles)
        {
            obj.SetActive(true);
        }
    }
    public void ActivateAllCollectables()
    {
        foreach (GameObject obj in collectables)
        {
            obj.SetActive(true);
        }

    }


}//class
