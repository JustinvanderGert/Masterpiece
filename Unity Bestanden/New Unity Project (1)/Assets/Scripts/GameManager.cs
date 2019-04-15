using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> HidingPosList;


    public Transform FindClosest(Vector3 MyPos)
    {
        //Finds the closest HidingBush.
        Transform Closest = null;
        float MinDistance = Mathf.Infinity;

        foreach (Transform ObjectToCheck in HidingPosList)
        {
            float Distance = Vector3.Distance(MyPos, ObjectToCheck.position);
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