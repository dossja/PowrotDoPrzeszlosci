using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDissolve : MonoBehaviour
{
    private Material material;

    private bool isDead = false;
    private bool isHurt = false;
    private float fadeValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            fadeValue -= Time.deltaTime;

            if(fadeValue <= 0f)
            {
                isDead = false;
                isHurt = false;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                PlayerAlive();
            }

            material.SetFloat("_Fade", fadeValue);
        }

        if(isHurt)
        {
            fadeValue -= (Time.deltaTime + 0.02f);

            Debug.Log(fadeValue);

            if(fadeValue <= 0.5f)
            {
                isHurt = false;
                fadeValue = 1f;
            }

            material.SetFloat("_Fade", fadeValue);
        }
    }

    public void PlayerDead()
    {
        isDead = true;
    }

    public void PlayerHurt()
    {
        isHurt = true;
    }

    public void PlayerAlive()
    {
        fadeValue = 1f;
        material.SetFloat("_Fade", fadeValue);
    }
}
