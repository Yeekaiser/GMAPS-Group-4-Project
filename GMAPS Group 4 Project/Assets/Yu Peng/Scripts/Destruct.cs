using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject shattered;
    public float force;

    void Update()
    {
        //if (Input.GetKeyDown("a"))
            //Shatter();
    }

    public void OnCollisionEnter(Collision collision)
    {
        force = collision.relativeVelocity.y;
        Debug.Log(force);
        Shatter();
    }

    public void Shatter()
    {
        if (force > 10f)
        {
            Instantiate(shattered, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
