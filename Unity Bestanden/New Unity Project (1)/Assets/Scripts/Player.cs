using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    RigidbodyFirstPersonController movementController;
    Camera PlayerCam;
    Boat boatScript;
    GameObject BoatObject;

    public GameObject ClosestDock;
    public float RangeTillBoat;

    void Start()
    {
        //Presets all private variables.
        BoatObject = GameObject.FindGameObjectWithTag("Boat");
        boatScript = BoatObject.GetComponent<Boat>();

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            BoatAcces();
        }
    }

    private void BoatAcces()
    {
        if (UnityEngine.Vector3.Distance(transform.position, BoatObject.transform.position) < RangeTillBoat)
        {
            if (!boatScript.Driving)
            {
                //Sets everything to get on the boat.
                movementController.enabled = false;
                boatScript.EnterBoat(PlayerCam);
            }
            else
            {
                //Resets everything to get off the boat.
                ClosestDock = boatScript.ExitBoat(PlayerCam);
                movementController.enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "Respawn")
        {
            GetComponent<Rigidbody>().velocity = new UnityEngine.Vector3(0, 0, 0);
            transform.position = ClosestDock.GetComponent<Dock>().PlayerEnterPos.transform.position;
            transform.rotation = ClosestDock.GetComponent<Dock>().PlayerEnterPos.transform.rotation;
        }
    }
}