using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour
{
    public Transform PlayerEnterPos;
    Boat boatScript;

    private void Start()
    {
        boatScript = FindObjectOfType<Boat>();
        boatScript.Docks.Add(gameObject);
    }
}