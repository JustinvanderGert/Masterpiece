using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Boat : MonoBehaviour
{
    public List<GameObject> Docks;
    public GameObject Player;
    Player PlayerScript;
    Camera BoatCam;
    Rigidbody Rb;

    public Transform PlayerDrivingPos;

    public bool Driving = false;

    public float RotSpeed;
    public float MovSpeed;
    public float MaxSpeed;
    public float MinDistanceToExit;


    void Start()
    {
        //Sets all private variables.
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<Player>();
        BoatCam = GetComponentInChildren<Camera>();
        Rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        if (Driving)
        {
            Rb.isKinematic = false;
            //Allows steering.
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
                Rb.velocity = -transform.right * (Input.GetAxis("Vertical") * MovSpeed * Time.deltaTime);
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
        else { Rb.isKinematic = true; }
    }

    public void EnterBoat(Camera PlayerCam)
    {
        //Sets everything to get on the boat.
        Driving = true;
        BoatCam.enabled = true;
        PlayerCam.enabled = false;
    }

    public GameObject ExitBoat(Camera PlayerCam)
    {
        //Resets everything to get off the boat.
        GameObject ClosestDock = FindClosest(Docks);
        if (ClosestDock == null)
            return null;

        Dock ClosestDockScript = ClosestDock.GetComponent<Dock>();

        Rb.velocity = new UnityEngine.Vector3(0, 0, 0);
        Player.transform.position = ClosestDockScript.PlayerEnterPos.transform.position;
        //Player.transform.rotation = ClosestDockScript.PlayerEnterPos.transform.rotation;
        transform.position = ClosestDockScript.BoatSpawnPos.transform.position;
        transform.rotation = ClosestDockScript.BoatSpawnPos.transform.rotation;

        Driving = false;
        BoatCam.enabled = false;
        PlayerCam.enabled = true;
        return ClosestDock;
    }

    public GameObject FindClosest(List<GameObject> ListToCheck)
    {
        //Finds the closest Dock.
        GameObject Closest = null;
        float MinDistance = MinDistanceToExit;

        foreach (GameObject ObjectToCheck in ListToCheck)
        {
            Dock DockScript = ObjectToCheck.GetComponent<Dock>();
            float Distance = UnityEngine.Vector3.Distance(transform.position, DockScript.PlayerEnterPos.transform.position);
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