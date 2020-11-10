using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private PlayerDissolve playerDissolve;

    private void Start()
    {
        health = 3;
    }

    void Update()
    {
        if (health > 3)
            health = 3;

        else if (health == 0)
            PlayerDeath();

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void RemoveHeart()
    {
        health -= 1;
        if (health > 0)
            playerDissolve.PlayerHurt();
    }

    private void PlayerDeath()
    {
        playerDissolve.PlayerDead();
    }

    private void PlayerHurt()
    {
        playerDissolve.PlayerHurt();
    }
}
