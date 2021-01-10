using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for player statisticks
/// </summary>
[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }

    public float Speed { get; set; }
    public float RunSpeed { get => runSpeed; }
    public float JumpForce { get => jumpForce; }

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float runSpeed;
}
