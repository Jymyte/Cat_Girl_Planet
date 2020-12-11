using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int nextSpot;

    void Start()
    {
        waitTime = startWaitTime;
        this.transform.position = moveSpots[0].position;
    }

    void Update()
    {
        if (nextSpot >= moveSpots.Length) nextSpot = 0;

        transform.position =  Vector3.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[nextSpot].position) < 0.1f ) {
            if (waitTime <= 0) {
                nextSpot++;
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
