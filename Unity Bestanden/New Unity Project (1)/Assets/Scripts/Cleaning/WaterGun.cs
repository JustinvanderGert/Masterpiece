using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    Player player;
    public Transform SpawnBubble;
    public GameObject WaterBubble;


    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(WaterBubble, SpawnBubble);
        }
    }
}