using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovControls : MonoBehaviour
{
    public float MoveSpeed;

    float moveHorizontal;
    float moveVertical;
    Vector3 movement;

    void Start()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Movement();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Movement();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2F);
    }

    void Movement()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        //if (Input.GetAxisRaw("Horizontal") >= 1 && Input.GetAxisRaw("Vertical") >= 1)
        //{
        //    movement = new Vector3(Input.GetAxisRaw("Horizontal") / 2, 0, Input.GetAxisRaw("Vertical") / 2);
        //}

        transform.Translate(movement * MoveSpeed * Time.deltaTime, Space.World);
    }
}