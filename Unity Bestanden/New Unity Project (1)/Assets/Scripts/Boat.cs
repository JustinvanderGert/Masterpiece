using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    Rigidbody Rb;
    bool Driving = true;

    public float RotSpeed;
    public float MovSpeed;
    public float MaxSpeed;


    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Driving)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -RotSpeed * Time.deltaTime, 0, Space.Self);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.Self);
            }

            if (Input.GetKey(KeyCode.W) && Rb.velocity.x < MaxSpeed)
            {
                Rb.AddForce(transform.forward * MovSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) && Rb.velocity.x > 0)
            {
                Rb.AddForce(-transform.forward * MovSpeed * Time.deltaTime);
                if(Rb.velocity.x < 0)
                {
                    Rb.velocity = new Vector3(0, 0, 0);
                }
            }
        }
    }
}