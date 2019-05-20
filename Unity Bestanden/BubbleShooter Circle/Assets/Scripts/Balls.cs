using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public List<GameObject> Waypoints;
    public float Speed;
    int i = 0;

    void Start()
    {
        Waypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoints"));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[i].transform.position, Speed * Time.deltaTime);

        float Distance = Vector3.Distance(transform.position, Waypoints[i].transform.position);
        if (Distance <= 0)
        {
            i++;
        }
    }
}