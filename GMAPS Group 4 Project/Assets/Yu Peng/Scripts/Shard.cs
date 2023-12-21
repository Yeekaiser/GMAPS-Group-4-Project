using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    Vector3 impulseForce = new Vector3(3f, 3f, 3f);
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(impulseForce, ForceMode.Impulse); //Applies impulse force on the piece rigidbody
        StartCoroutine(Disappear()); //start the disappearing process
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5);  //Delay 5 seconds
        Destroy(gameObject); //removes the piece
    }
}
