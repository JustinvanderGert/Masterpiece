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
        //Presets all private variables.
        BoatObject = GameObject.FindGameObjectWithTag("Boat");
        boatScript = BoatObject.GetComponent<Boat>();
        BoatCam = BoatObject.GetComponentInChildren<Camera>();
        BoatCam.enabled = false;

        PlayerCam = GetComponentInChildren<Camera>();
        movementController = GetComponent<RigidbodyFirstPersonController>();
    }
    
    void Update()
    {
        if (boatScript.Driving)
        {
            //Keeps the player on the boat while driving.
            transform.position = boatScript.PlayerDrivingPos.position;
            transform.rotation = boatScript.PlayerDrivingPos.rotation;
        }
        float distance = Vector3.Distance(transform.position, BoatObject.transform.position);
        if(distance < RangeTillBoat)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!boatScript.Driving)
                {
                    //Sets everything to get on the boat.
                    boatScript.Driving = true;
                    BoatCam.enabled = true;
                    PlayerCam.enabled = false;
                    movementController.enabled = false;
                }
                else
                {
                    //Resets everything to get off the boat.
                    GameObject ClosestDock = boatScript.FindClosest(boatScript.Docks);
                    Dock ClosestDockScript = ClosestDock.GetComponent<Dock>();

                    BoatObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    transform.position = ClosestDockScript.PlayerEnterPos.transform.position;
                    transform.rotation = ClosestDockScript.PlayerEnterPos.transform.rotation;
                    BoatObject.transform.position = ClosestDockScript.BoatSpawnPos.transform.position;
                    BoatObject.transform.rotation = ClosestDockScript.BoatSpawnPos.transform.rotation;

                    boatScript.Driving = false;
                    BoatCam.enabled = false;
                    PlayerCam.enabled = true;
                    movementController.enabled = true;
                }
            }
        }
    }
}