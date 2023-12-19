using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    [SerializeField] Transform bulletSpawn;
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Call the method to shoot a bullet
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instantiate a bullet at the gun's position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            // Apply force to the bullet in the forward direction of the gun
            bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component.");
        }

        // Optional: Destroy the bullet after a certain time (adjust as needed)
        Destroy(bullet, 3f);
    }
}
