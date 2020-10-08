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
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private LayerMask groundLayer;

    public Rigidbody2D Rigidbody { get => rigidbody; }
    public AnyStateAnimator Animator { get => animator; } 
    public Collider2D Collider { get => collider; }
    public LayerMask GroundLayer { get => groundLayer; }   
}