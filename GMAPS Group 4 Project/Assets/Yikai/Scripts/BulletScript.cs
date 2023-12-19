using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletDamage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            // Get the Breakable script from the collided object
            Breakable breakable = collision.gameObject.GetComponent<Breakable>();

            // Check if the Breakable script is found
            if (breakable != null)
            {
                // Reduce the wall's health
                breakable.TakeDmg(bulletDamage);
            }
        }
        Destroy(gameObject);
    }
}
