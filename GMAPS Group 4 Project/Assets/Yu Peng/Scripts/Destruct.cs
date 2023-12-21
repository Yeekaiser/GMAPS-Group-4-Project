using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject shattered; //slot for shattered version
    public GameObject particles; //slot for particle effect
    public AudioSource audioSource;
    public AudioClip breakSound;  //slot for audio clip

    public void OnCollisionEnter(Collision collision)
    {
        float force;

        //Calculating forces recieved
        force = collision.impulse.magnitude;
        Debug.Log("Force recieved by block: " + force);

        if (force >= 13f)
        {
            Shatter(); //calls this function to 'destruct'
        }
    }

    public void Shatter()
    {
        Instantiate(shattered, transform.position, transform.rotation); //spawn shattered version
        Instantiate(particles, transform.position, transform.rotation); //spawn particle effect
        audioSource.PlayOneShot(breakSound); //plays block breaking audio once

        gameObject.SetActive(false); //hide original object
    }
}
