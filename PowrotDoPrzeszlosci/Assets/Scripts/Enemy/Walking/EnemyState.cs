using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Transform groundDetection;

    Animator animator;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
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

    private void StopChase()
    {
        eye.SetActive(false);
        animator.Play("idle");
        rigidbody.velocity = Vector2.zero;
    }

    public void Dead()
    {
        alive = false;
    }

    public bool IsAlive()
    {
        return alive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive() && collision.gameObject.name == "Player")
        {
            player.GetComponent<Health>().RemoveHeart();
        }
    }
}
