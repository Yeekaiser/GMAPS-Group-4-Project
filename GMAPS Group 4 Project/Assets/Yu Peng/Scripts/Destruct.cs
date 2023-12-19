using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject shattered; //slot for shattered version
    public GameObject particles; //slot for particle effect

    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        float xforce;
        float yforce;
        float zforce;

        //Calculating forces recieved
        xforce = collision.relativeVelocity.x;
        yforce = collision.relativeVelocity.y;
        zforce = collision.relativeVelocity.z;
        Debug.Log(xforce + ", " + yforce + ", " + zforce);

        if (xforce >= 13f || yforce >= 20f || zforce >= 13f)
        {
            Shatter(); //calls this function to 'destruct'
        }

        if (xforce <= -13f || zforce <= -13f)
        {
            Shatter(); //calls this function to 'destruct'
        }
    }

    public void Shatter()
    {
        Instantiate(shattered, transform.position, transform.rotation); //spawn shattered version
        Instantiate(particles, transform.position, transform.rotation); //spawn particle effect
        gameObject.SetActive(false); //remove original object
    }
}
