using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private AnyStateAnimator animator;

    public Rigidbody2D Rigidbody { get => rigidbody; }
    public AnyStateAnimator Animator { get => animator; }
}