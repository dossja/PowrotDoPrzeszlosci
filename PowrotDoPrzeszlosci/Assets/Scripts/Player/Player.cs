using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for connecting all player scripts
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private PlayerComponents components;
    private PlayerUtilities utilities;
    private PlayerActions actions;

    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private PlayerPlatformDown playerPlatform;

    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }
    public PlayerActions Actions { get => actions; }
    public PlayerUtilities Utilities { get => utilities; }

    // Start is called before the first frame update
    /// <summary>
    /// Set ups classes constructors at start.
    /// </summary>
    private void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        actions = new PlayerActions(this, particle, playerPlatform);
        utilities = new PlayerUtilities(this, joystick);
        stats.Speed = stats.RunSpeed;

        AnyStateAnimation[] stateAnimations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Idle"),
            new AnyStateAnimation(RIG.BODY, "Run"),
            new AnyStateAnimation(RIG.BODY, "Jump"),
            new AnyStateAnimation(RIG.BODY, "Fall"),
            new AnyStateAnimation(RIG.BODY, "Crouch"),
        };

        components.Animator.AddAnimations(stateAnimations);
    }

    // Update is called once per frame
    /// <summary>
    /// Updates the utilites every frame
    /// </summary>
    private void Update()
    {
        utilities.HandleInput();
        utilities.HandleAir();
    }

    /// <summary>
    /// Updates the move
    /// </summary>
    private void FixedUpdate()
    { 
        actions.Move(transform);
    }

    /// <summary>
    /// Gets the joystick vertical.
    /// </summary>
    /// <returns>A float.</returns>
    public float GetJoystickVertical()
    {
        return joystick.Vertical;
    }    
}
