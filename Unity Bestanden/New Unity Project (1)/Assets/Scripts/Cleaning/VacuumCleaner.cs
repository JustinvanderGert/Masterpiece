using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : MonoBehaviour
{
    bool Active;


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Active = true;
        }
        else
            Active = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trash" && Active)
        {
            Destroy(other.gameObject);
        }
    }
}