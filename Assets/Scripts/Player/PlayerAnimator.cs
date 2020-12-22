using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;

    private void Awake() {
        anim = GetComponent<Animator> ();
        body = gameObject.transform.root.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float velX = Mathf.Abs(body.velocity.x);
        float velY = Mathf.Abs(body.velocity.y);
        float velZ = Mathf.Abs(body.velocity.z);

        if (velX > 0 || velY > 0 || velZ > 0) {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }    
    }
}
