using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public List<Color> BallColors;

    public GameObject Ball;

    public float SpawnTimer;
    public int BallsToSend;


    void Start()
    {
        BallColors.Add(Color.blue);
        BallColors.Add(Color.red);
        BallColors.Add(Color.green);

        StartCoroutine(Spawner());
    }


    public IEnumerator Spawner()
    {
        int i = Random.Range(0, BallColors.Count);
        BallsToSend--;

        yield return new WaitForSeconds(SpawnTimer);
        GameObject BallToColor = Instantiate(Ball, transform.position, transform.rotation);
        BallToColor.GetComponent<Renderer>().material.SetColor("_Color", BallColors[i]);

        if (BallsToSend >= 1)
            StartCoroutine(Spawner());
    }
}