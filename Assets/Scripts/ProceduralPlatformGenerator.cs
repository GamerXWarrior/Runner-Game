using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralPlatformGenerator : MonoBehaviour
{
    public Transform platform;
    private Vector3 nextPos; 

    void Start()
    {
        nextPos.z = -168f;
        StartCoroutine(spawnPlatform());
    }

   IEnumerator spawnPlatform()
    {
        yield return new WaitForSeconds(3);
        Instantiate(platform, nextPos, platform.rotation);
        nextPos.z -= 56;
        StartCoroutine(spawnPlatform());
    }
}
