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
            // Get the Wall script from the collided object
            Breakable breakable = collision.gameObject.GetComponent<Breakable>();

            // Check if the Wall script is found
            if (breakable != null)
            {
                // Reduce the wall's health
                breakable.TakeDmg(bulletDamage);

                // Destroy the bullet
                Destroy(gameObject);
            }
        }
        else
        {
            // Destroy the bullet for other collisions (e.g., with non-wall objects)
            Destroy(gameObject);
        }
    }
}
