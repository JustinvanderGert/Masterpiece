using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBush : MonoBehaviour
{
    GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.HidingPosList.Add(transform.position);
    }
}