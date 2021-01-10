using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for enemy states.
/// </summary>
public class EnemyState : MonoBehaviour
{
    private bool alive;
    [SerializeField]
    GameObject eye;

    [SerializeField]
    private Player player;

    [SerializeField]
    float enemyEyesight;
    [SerializeField]
    float enemySpeed;

    [SerializeField]
    private Transform groundDetection;

    private Animator animator;

    private Rigidbody2D rigidbody;

    private AudioSource audioSource;

    // Start is called before the first frame update
    /// <summary>
    /// Set up at the start.
    /// </summary>
    void Start()
    {
        alive = true;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /// <summary>
    /// Updates the game every frame.
    /// For attacking player.
    /// </summary>
    void Update()
    {
        if(alive == true)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1);

            if (distanceToPlayer < enemyEyesight)
            {
                if (groundInfo.collider == false)
                {
                    GroundEnded();
                }
                else
                {
                    ChasePlayer();
                }
            }
            else
            {
                StopChase();
            }
        }
        else
        {
            StopChase();
        }
    }

    /// <summary>
    /// Chases the player and changes animation into correct one.
    /// </summary>
    private void ChasePlayer()
    {
        eye.SetActive(true);
        animator.Play("run");
        if (transform.position.x < player.transform.position.x)
        {
            rigidbody.velocity = new Vector2(enemySpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.transform.position.x)
        {
            rigidbody.velocity = new Vector2(-enemySpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    /// <summary>
    /// Class for chcecking if ground has ended under enemy legs. 
    /// In order for enemy not to fall from map.
    /// </summary>
    private void GroundEnded()
    {
        eye.SetActive(false);
        animator.Play("idle");
        rigidbody.velocity = Vector2.zero;

        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    /// <summary>
    /// Stops the chase and changes animation.
    /// </summary>
    private void StopChase()
    {
        eye.SetActive(false);
        animator.Play("idle");
        rigidbody.velocity = Vector2.zero;
    }

    /// <summary>
    /// Enemy died, sets alive bool into false.
    /// </summary>
    public void Dead()
    {
        alive = false;
        audioSource.Play();
    }

    /// <summary>
    /// Getter for enemy alive state.
    /// </summary>
    /// <returns>A bool with information about enemy alive state.</returns>
    public bool IsAlive()
    {
        return alive;
    }

    /// <summary>
    /// When collision, checks if collides with player, then removes player heart
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive() && collision.gameObject.name == "Player")
        {
            player.GetComponent<Health>().RemoveHeart();
        }
    }
}
