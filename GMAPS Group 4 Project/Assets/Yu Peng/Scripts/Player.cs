using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 15f;
    float rotationSpeed = 125f;
    Rigidbody rb;
    public GameObject camera;
    public float yOffset = 10;  //displacement between camera and car in y axis
    public float zOffset = -10;  //displacement between camera and car in z axis

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        //Player Movement
        Rotate();
        Move();
        
        //Camera Movement
        RepositionCamera();
    }

    public void Rotate()
    {
        float turnInput = Input.GetAxis("Horizontal");
        Quaternion Rotation = Quaternion.Euler(0f, turnInput * rotationSpeed * Time.deltaTime, 0f); //convert vector3 to rotation
        rb.MoveRotation(rb.rotation * Rotation); //rotates the car rigidbody
    }

    public void Move()
    {
        float forwardInput = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(0, 0, forwardInput) * speed;
        rb.velocity = rb.rotation * Movement; //move the rigidbody in the front direction of car
    }

    public void RepositionCamera()
    {
        //Setting camera position to car position plus offsets
        camera.transform.position = new Vector3(rb.position.x, rb.position.y + yOffset, rb.position.z + zOffset);
    }
}
