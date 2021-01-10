using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for managing player health
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    private PlayerDissolve playerDissolve;
    private AudioSource audioSource;

    /// <summary>
    /// Set ups player health and dissolve class at the start.
    /// </summary>
    private void Start()
    {
        playerDissolve = GetComponentInChildren<PlayerDissolve>();
        audioSource = GetComponent<AudioSource>();
        health = 3;
    }

    /// <summary>
    /// Updates the health.
    /// </summary>
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

    /// <summary>
    /// Removes the heart when attackted by enemy (enemy invoces this).
    /// </summary>
    public void RemoveHeart()
    {
        health -= 1;
        if (health > 0)
        {
            audioSource.Play();
            playerDissolve.PlayerHurt();
        }
    }

    /// <summary>
    /// Plays playerDeath dissolve method with level restart.
    /// </summary>
    private void PlayerDeath()
    {
        audioSource.Play();
        playerDissolve.PlayerDead();
    }
/*
    /// <summary>
    /// Plays playerHurt dissolve animation.
    /// </summary>
    private void PlayerHurt()
    {
        playerDissolve.PlayerHurt();
    }*/
}
