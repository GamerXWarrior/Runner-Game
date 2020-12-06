using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float zInd;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       
            rb.velocity = new Vector3(0, 0, zInd);
    }

    void Update()
    {

    }
}
