using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move));        
    }
}
