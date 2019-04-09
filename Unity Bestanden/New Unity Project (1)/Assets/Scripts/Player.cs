using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    RigidbodyFirstPersonController movementController;
    Camera PlayerCam;
    Camera BoatCam;
    Boat boatScript;
    GameObject BoatObject;

    public float RangeTillBoat;

    void Start()
    {
        BoatObject = GameObject.FindGameObjectWithTag("Boat");
        boatScript = BoatObject.GetComponent<Boat>();
        BoatCam = BoatObject.GetComponentInChildren<Camera>();
        BoatCam.enabled = false;

        PlayerCam = GetComponentInChildren<Camera>();
        movementController = GetComponent<RigidbodyFirstPersonController>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, BoatObject.transform.position);
        if(distance < RangeTillBoat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!boatScript.Driving)
                {
                    transform.position = boatScript.PlayerDrivingPos.position;
                    boatScript.Driving = true;
                    BoatCam.enabled = true;
                    PlayerCam.enabled = false;
                    movementController.enabled = false;
                }
                else
                {
                    transform.position = boatScript.FindClosest(boatScript.Docks).transform.position;
                    boatScript.Driving = false;
                    BoatCam.enabled = false;
                    PlayerCam.enabled = true;
                    movementController.enabled = true;
                    transform.SetParent(null);
                }
            }
        }
    }
}