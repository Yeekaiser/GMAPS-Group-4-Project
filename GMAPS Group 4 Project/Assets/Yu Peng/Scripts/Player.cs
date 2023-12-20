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
        Quaternion Rotation = Quaternion.Euler(new Vector3(0f, turnInput * rotationSpeed * Time.deltaTime, 0f));
        rb.MoveRotation(rb.rotation * Rotation); //rotates the car
    }

    public void Move()
    {
        float forwardInput = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(0, 0, forwardInput) * speed;
        rb.velocity = rb.rotation * Movement; //move in the front direction of car
    }

    public void RepositionCamera()
    {
        camera.transform.position = new Vector3(rb.position.x, rb.position.y + yOffset, rb.position.z + zOffset); //positions camera to red car
    }
}
