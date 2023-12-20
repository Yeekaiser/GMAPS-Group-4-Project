using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestruct : MonoBehaviour
{
    public GameObject shattered; //slot for shattered version
    public GameObject particles; //slot for particle effect
    public AudioSource audioSource;
    public AudioClip carCrashSound;  //slot for audio clip

    public void OnCollisionEnter(Collision collision)
    {
        float force;

        //Calculating forces recieved
        force = collision.impulse.magnitude;
        Debug.Log("Force recieved by car: " + force);

        if (force >= 100f & collision.gameObject.tag == "Wall")  //only destruct when hitting a wall
        {
            Shatter(); //calls this function to 'destruct'
        }
    }

    public void Shatter()
    {
        Instantiate(shattered, transform.position, transform.rotation); //spawn shattered version
        Instantiate(particles, transform.position, transform.rotation); //spawn particle effect
        audioSource.PlayOneShot(carCrashSound); //plays car crash audio

        gameObject.SetActive(false); //remove original object
    }
}
