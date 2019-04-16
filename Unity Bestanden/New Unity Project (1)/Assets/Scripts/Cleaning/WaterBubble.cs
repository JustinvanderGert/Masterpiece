using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubble : MonoBehaviour
{
    public Vector3 CleanSpeed;
    public Animator WaterAnim;


    private void Update()
    {
        if (WaterAnim.GetCurrentAnimatorStateInfo(0).IsName("WaterBubble2"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Smurrie")
        {
            Smurrie smurrieScript = other.gameObject.GetComponent<Smurrie>();
            smurrieScript.Cleaning(CleanSpeed);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}