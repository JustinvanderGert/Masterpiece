using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Vector3> HidingPosList;


    public Vector3 FindClosest(Vector3 MyPos)
    {
        //Finds the closest HidingBush.
        Vector3 Closest = new Vector3(0,0,0);
        float MinDistance = Mathf.Infinity;

        foreach (Vector3 ObjectToCheck in HidingPosList)
        {
            float Distance = Vector3.Distance(MyPos, ObjectToCheck);
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