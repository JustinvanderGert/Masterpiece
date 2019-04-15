using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBush : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    public GameObject IncomingTrashBag;

    public float HideRange;
    public bool IsHiding = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.HidingPosList.Add(transform);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (IncomingTrashBag && IsHiding)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= HideRange)
            {
                Debug.Log("Garbage leaves cover");
                IncomingTrashBag.GetComponent<TrashBag>().DoneHiding();
                //IsHiding = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TrashBag")
        {
            IsHiding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TrashBag")
        {
            IsHiding = false;
        }
    }
}