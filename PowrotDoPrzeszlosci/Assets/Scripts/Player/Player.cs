using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private PlayerComponents components;
    private PlayerReferences references;
    private PlayerUtilities utilities;
    private PlayerActions actions;

    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private ParticleSystem particle;

    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }
    public PlayerActions Actions { get => actions; }
    public PlayerUtilities Utilities { get => utilities; }

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        actions = new PlayerActions(this, particle);
        utilities = new PlayerUtilities(this, joystick);
        stats.Speed = stats.RunSpeed;

        AnyStateAnimation[] stateAnimations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Idle"),
            new AnyStateAnimation(RIG.BODY, "Run"),
            new AnyStateAnimation(RIG.BODY, "Jump"),
            new AnyStateAnimation(RIG.BODY, "Fall"),
        };

        components.Animator.AddAnimations(stateAnimations);
    }

    // Update is called once per frame
    private void Update()
    {
        Utilities.HandleInput();
        utilities.HandleAir();
    }

    private void FixedUpdate()
    {
        actions.Move(transform);
    }
}
