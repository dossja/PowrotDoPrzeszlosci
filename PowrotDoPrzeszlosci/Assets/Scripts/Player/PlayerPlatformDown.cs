using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing if player can go down the platform.
/// </summary>
public class PlayerPlatformDown : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    private float waitingTime;

    private bool crouch;

    /// <summary>
    /// Set ups at the start.
    /// </summary>
    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
        waitingTime = 0.8f;
    }

    /// <summary>
    /// Let's the player fall from platform if player is crouching and waited enough time.
    /// </summary>
    private void Update()
    {
        if (crouch)
        {
            if (waitingTime <= 0f)
            {
                platformEffector.rotationalOffset = 0f;
                crouch = false; 
                waitingTime = 0.8f;
            }
            else if (waitingTime <= 0.5f)
            {
                platformEffector.rotationalOffset = 180f;
                waitingTime -= Time.deltaTime;
            }
            else
                waitingTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Changes crouch into true if player wants to go down the platform.
    /// </summary>
    public void GoingDown()
    {
        crouch = true;
    }
}
