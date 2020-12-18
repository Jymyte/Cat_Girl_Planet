using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    [SerializeField]
    private Vector3 turnAngle, startingAngle, targetAngle, speed, currentAngle;

    [SerializeField]
    private float turnTime, startWaitTime;
    private float waitTime;
    
    private void Start() {
        waitTime = startWaitTime;
        speed = turnAngle / turnTime;
        startingAngle = transform.position;
        targetAngle.y = startingAngle.y + turnAngle.y;
    }

    private void Update() {
        rotateTowards();

        if ((transform.rotation.eulerAngles.y >= targetAngle.y && targetAngle.y > startingAngle.y) || (transform.rotation.eulerAngles.y <= startingAngle.y)) {
            if (waitTime <= 0) {
                changeTargetAngle();
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void changeTargetAngle() {
        if (targetAngle == startingAngle) {
            targetAngle.y = startingAngle.y + turnAngle.y;
        } else {
            targetAngle = startingAngle;
        }
    }

    private void rotateTowards() {
        if (targetAngle.y > startingAngle.y) {
            currentAngle.y += Time.deltaTime * speed.y;
        } else {
            currentAngle.y -= Time.deltaTime * speed.y;
        }

        gameObject.transform.eulerAngles = currentAngle;
    }
}
