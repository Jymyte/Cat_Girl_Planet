using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float speed = 2f;
    [Tooltip("Half of total angle, ie value of 90 will cover 180")]
    public float maxRotation = 90f;
    [Tooltip("0 = up, 90 = right etc")]
    public float startRotation = 0;
    public float waitTime = 1;
    public bool wait = false;

    float prevY;

    float ourTime = 0;
    bool clockwise;

    void Update()
    {
        if (wait)
            return;

        float y = startRotation + maxRotation * Mathf.Sin(ourTime * speed);

        transform.rotation = Quaternion.Euler(0f, y, 0f);

        ourTime += Time.deltaTime;

        CheckWait(y);

        prevY = y;
    }

    private void CheckWait(float y)
    {
        if (prevY > y)
        {
            if (clockwise == true)
                BeginWait();
            else
                clockwise = false;
        }
        else
        {
            if (clockwise == false)
                BeginWait();
            else
                clockwise = true;
        }
    }

    private void BeginWait()
    {
        wait = true;
        clockwise = !clockwise;
        Invoke(nameof(OnTimerElapse), waitTime);
    }

    void OnTimerElapse()
    {
        wait = false;
    }
}
