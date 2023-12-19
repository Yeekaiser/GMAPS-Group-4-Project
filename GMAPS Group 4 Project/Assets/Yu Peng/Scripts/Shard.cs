using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    public float impulseForce = 3f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, impulseForce, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
