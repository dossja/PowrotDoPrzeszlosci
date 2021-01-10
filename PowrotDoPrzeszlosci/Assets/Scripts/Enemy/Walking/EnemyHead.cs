using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for enemy head.
/// If the head has been hit, then enemy dies
/// </summary>
public class EnemyHead : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;

    private Collider2D headCollider;
    private bool dead;
    private int iter;

    /// <summary>
    /// Set up at start
    /// </summary
    private void Start()
    {
        headCollider = GetComponent<Collider2D>();
        dead = false;
        iter = 0;
    }

    /// <summary>
    /// If enemy dies, then changes texture size and after 100 frames, destroyes it.
    /// </summary>
    private void Update()
    {
        if (dead == true)
        {
            if (iter == 100)
            {
                Destroy(enemyObject);
            }
                
            float scale = (100 - iter) / 100f;
            enemyObject.transform.localScale = new Vector2(scale, scale);
            enemyObject.GetComponent<Collider2D>().transform.localScale = new Vector2(scale, scale);

            iter++;
        }
    }

    /// <summary>
    /// When head collides with player, then enemy dies
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            enemyObject.GetComponent<EnemyState>().Dead();
            dead = true;
        }
    }
}
