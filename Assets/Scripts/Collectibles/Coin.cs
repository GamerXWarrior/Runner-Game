using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerView>())
        {
            UIService.Instance.UpdateCoinsCount();
            gameObject.SetActive(false);
        }
    }
}
