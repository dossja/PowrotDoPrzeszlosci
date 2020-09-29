using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }

    public float Speed { get; set; }
    public float RunSpeed { get => runSpeed; }

    [SerializeField]
    private float runSpeed;
}
