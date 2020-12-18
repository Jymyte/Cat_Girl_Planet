using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    [SerializeField]
    private float turnTime, turnAngle, startingAngle;
    private float speed;
    
    private void Start() {
        speed = turnAngle / turnTime;
    }

    private void Update() {
        
    }
}
