using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private EnemyState enemyState;

    private GameObject enemyObject;
    // Start is called before the first frame update
    void Start()
    {
        enemyState = GetComponent<EnemyState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enemyState.isAlive() && collision.gameObject.name == "Player")
        {
            player.GetComponent<Health>().RemoveHeart();
        }
    }
}
