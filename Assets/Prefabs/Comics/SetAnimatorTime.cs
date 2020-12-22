using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Animator))]
public class SetAnimatorTime : MonoBehaviour
{
    [SerializeField] float speed = 1;

    private void Awake()
    {
        var animator = GetComponent<Animator>();

        Assert.IsNotNull(animator);


        animator.speed = speed;
    }
}

