using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public bool moving = false;

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            moving = true;
        } else {
            moving = false;
        }    
    }
}
