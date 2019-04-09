using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public List<GameObject> Docks;
    Rigidbody Rb;

    public bool Driving = false;

    public Transform PlayerDrivingPos;

    public float RotSpeed;
    public float MovSpeed;
    public float MaxSpeed;
    public float MinDistanceToExit;


    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
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

            if (Input.GetKey(KeyCode.W))
            {
                Rb.velocity = transform.forward * (Input.GetAxis("Vertical") * MovSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Rb.drag = 1;
                Rb.angularDrag = 1;
            }
            else
            {
                Rb.drag = 0.25f;
                Rb.angularDrag = 0.25f;
            }
        }
    }

    public GameObject FindClosest(List<GameObject> ListToCheck)
    {
        GameObject Closest = null;
        float MinDistance = Mathf.Infinity;

        foreach (GameObject ObjectToCheck in ListToCheck)
        {
            float Distance = Vector3.Distance(transform.position, ObjectToCheck.transform.position);
            if (MinDistance >= Distance)
            {
                Closest = ObjectToCheck;
                MinDistance = Distance;
                continue;
            }
        }

        return Closest;
    }
}