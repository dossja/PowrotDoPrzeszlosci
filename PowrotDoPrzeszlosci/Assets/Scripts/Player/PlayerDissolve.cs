using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for Dissolve animation on player texture.
/// </summary>
public class PlayerDissolve : MonoBehaviour
{
    private Material material;

    private bool isDead = false;
    private bool isHurt = false;
    private float fadeValue = 1f;

    // Start is called before the first frame update
    /// <summary>
    /// Set ups material at the start.
    /// </summary>
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    /// <summary>
    /// Updates the dissolve shader if player dies or is hurt.
    /// </summary>
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

    /// <summary>
    /// Sets player state into dead, when he lost all hearts.
    /// </summary>
    public void PlayerDead()
    {
        isDead = true;
    }

    /// <summary>
    /// Sets player state into hurt, when he is hitted by enemy.
    /// </summary>
    public void PlayerHurt()
    {
        isHurt = true;
    }

    /// <summary>
    /// When player is reborn, the fade value is changed.
    /// </summary>
    public void PlayerAlive()
    {
        fadeValue = 1f;
        material.SetFloat("_Fade", fadeValue);
    }
}
