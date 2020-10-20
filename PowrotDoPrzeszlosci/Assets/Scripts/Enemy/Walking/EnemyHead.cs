using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;

    private Collider2D headCollider;
    private bool dead;
    private int iter;

    private void Start()
    {
        headCollider = GetComponent<Collider2D>();
        dead = false;
        iter = 0;
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            enemyObject.GetComponent<EnemyState>().Dead();
            dead = true;
        }
    }
}
