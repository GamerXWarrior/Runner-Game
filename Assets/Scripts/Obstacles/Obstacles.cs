using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>())
        {
            Debug.Log("lada");
            PlayerService.Instance.TakeDamage();
            //StartCoroutine(DestroyObstacle());
            Destroy(gameObject);
        }
    }

   
    //IEnumerator DestroyObstacle()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Destroy(gameObject);
    //}
}
