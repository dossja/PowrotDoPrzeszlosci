﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player components and level layers.
/// </summary>
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
    [SerializeField]
    private LayerMask tileLayer;
    [SerializeField]
    private LayerMask enemyLayer;

    public Rigidbody2D Rigidbody { get => rigidbody; }
    public AnyStateAnimator Animator { get => animator; } 
    public Collider2D Collider { get => collider; }
    public LayerMask GroundLayer { get => groundLayer; }   
    public LayerMask EnemyLayer { get => enemyLayer; }
    public LayerMask TileLayer { get => tileLayer;}
}