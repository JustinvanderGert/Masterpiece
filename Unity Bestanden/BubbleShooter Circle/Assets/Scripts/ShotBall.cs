﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBall : MonoBehaviour
{
    bool Shot;

    public float Speed;
    public float LifeTime;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Shot)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

    public void Shoot()
    {
        gameObject.transform.parent = null;
        Shot = true;
        StartCoroutine(LivingTime());
    }


    IEnumerator LivingTime()
    {
        yield return new WaitForSeconds(LifeTime);

        Destroy(gameObject);
    }
}