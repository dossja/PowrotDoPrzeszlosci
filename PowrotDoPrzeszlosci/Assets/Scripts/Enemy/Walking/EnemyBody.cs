using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private EnemyState enemyState;
    // Start is called before the first frame update
    void Start()
    {
        enemyState = GetComponent<EnemyState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enemyState.isAlive() && collision.gameObject.name == "Player")
        {
            player.GetComponent<Health>().RemoveHeart();
        }
    }
}
