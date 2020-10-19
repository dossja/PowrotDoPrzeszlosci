using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField]
    GameObject eye;

    [SerializeField]
    Transform player;

    [SerializeField]
    float enemyEyesight;
    [SerializeField]
    float enemySpeed;

    [SerializeField]
    Transform groundDetection;

    Animator animator;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

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

    private void ChasePlayer()
    {
        eye.SetActive(true);
        animator.Play("run");
        if (transform.position.x < player.position.x)
        {
            rigidbody.velocity = new Vector2(enemySpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            rigidbody.velocity = new Vector2(-enemySpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void GroundEnded()
    {
        eye.SetActive(false);
        animator.Play("idle");
        rigidbody.velocity = Vector2.zero;

        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void StopChase()
    {
        eye.SetActive(false);
        animator.Play("idle");
        rigidbody.velocity = Vector2.zero;
    }
}
