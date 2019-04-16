using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour
{
    public GameObject PlayerEnterPos;
    public GameObject BoatSpawnPos;
    Boat boatScript;

    private void Start()
    {
        //Sets itelf into the boat-dock list.
        boatScript = FindObjectOfType<Boat>();
        boatScript.Docks.Add(gameObject);
    }
}