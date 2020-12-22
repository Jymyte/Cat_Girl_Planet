using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private Rigidbody player;

    private void Awake() {
        anim = GetComponent<Animator> ();
        player = gameObject.transform.root.GetComponent<Rigidbody>();
        Debug.Log(player + "    TÄSÄ PLAYER");
    }
    void Update()
    {
        float velX = Mathf.Abs(player.velocity.x);
        float velY = Mathf.Abs(player.velocity.y);

        if (velX > 0 || velY > 0) {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }    
    }
}
