using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 15f;
    float rotationSpeed = 125f;
    public Rigidbody rb;

    void Start()
    {

    }

    void Update()
    {
        //Car's Movement
        float turnInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        Quaternion Rotation = Quaternion.Euler(new Vector3(0f, turnInput * rotationSpeed * Time.deltaTime, 0f));
        rb.MoveRotation(rb.rotation * Rotation); //rotates the car

        Vector3 Movement = new Vector3(0, 0, forwardInput) * speed;
        rb.velocity = rb.rotation * Movement; //move in the front direction of car
    }
}
