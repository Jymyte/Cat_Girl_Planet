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

    void Update()
    {
        float y = startRotation + maxRotation * Mathf.Sin(Time.time * speed);

        transform.rotation = Quaternion.Euler(0f, y, 0f);
    }
}
