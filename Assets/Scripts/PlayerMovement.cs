using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(1f,20f)]
    public float movementSpeed = 2;

    Vector2 movement;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * movementSpeed; movement.y = Input.GetAxis("Vertical") * movementSpeed;
        //print(movement/movementSpeed);
        rb.velocity = movement;
    }
}
