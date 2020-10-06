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

    public PlayerComponents Components { get => components; }
    public PlayerStats Stats { get => stats; }
    public PlayerActions Actions { get => actions; }

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.RunSpeed;

        AnyStateAnimation[] stateAnimations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Idle"),
            new AnyStateAnimation(RIG.BODY, "Run"),
        };

        components.Animator.AddAnimations(stateAnimations);
    }

    // Update is called once per frame
    private void Update()
    {
        utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        actions.Move(transform);
    }
}
