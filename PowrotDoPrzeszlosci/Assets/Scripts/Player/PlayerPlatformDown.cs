using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformDown : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    private float waitingTime;

    private bool crouch;

    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
        waitingTime = 0.8f;
    }

    private void Update()
    {
        if (crouch)
        {
            Debug.Log(waitingTime);
            if (waitingTime <= 0f)
            {
                Debug.Log("Change");
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

    public void GoingDown()
    {
        crouch = true;
    }
}
