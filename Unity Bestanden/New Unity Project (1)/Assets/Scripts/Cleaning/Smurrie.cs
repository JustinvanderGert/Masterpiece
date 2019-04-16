using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smurrie : MonoBehaviour
{
    Player player;

    public Vector3 MinSize;


    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {

    }

    public void Cleaning(Vector3 ShrinkSpeed)
    {
        if (transform.localScale.x <= MinSize.x || transform.localScale.y <= MinSize.y)
        {
            Destroy(gameObject);
        }
        else
            transform.localScale -= ShrinkSpeed;
    }
}