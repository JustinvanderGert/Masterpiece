using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TrashBag : MonoBehaviour
{
    GameManager gameManager;
    Player PlayerScript;
    NavMeshAgent Agent;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        PlayerScript = FindObjectOfType<Player>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider Other)
    {
        if (Other.tag == "Player")
        {
            //Checks if there is a wall in between the player and trash eyes.
            if (Physics.Raycast(transform.position, Other.transform.position - transform.position, out RaycastHit hit, Mathf.Infinity))
            {
                GameObject HitObject;
                HitObject = hit.collider.gameObject;

                if (HitObject.tag == "Player")
                {
                    SawPlayer();
                }
            }
        }
    }

    public void SawPlayer()
    {
        Debug.Log("Did Hit");
        Agent.destination = gameManager.FindClosest(transform.position);
    }
}