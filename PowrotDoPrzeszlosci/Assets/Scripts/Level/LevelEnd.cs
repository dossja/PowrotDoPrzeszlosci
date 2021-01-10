using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for checking the conditions for level end.
/// </summary>
public class LevelEnd : MonoBehaviour
{
    private int questionsAnswered;
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private GameObject light;
    [SerializeField]
    private LevelMenuController levelMenuController;
    [SerializeField]
    private FadeLevel fadeLevel;

    /// <summary>
    /// Set up no of questionsAnswered at the start.
    /// </summary>
    void Start()
    {
        questionsAnswered = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    /// <summary>
    /// Increments the no of questions answered
    /// </summary>
    public void QuestionAnswered()
    {
        questionsAnswered += 1;
    }


    /// <summary>
    /// When 3 questions are answered, the door light (doors to go to the next level) is being activated.
    /// </summary>
    void Update()
    {
        if(questionsAnswered == 3)
        {
            light.SetActive(true);
            GetComponent<CapsuleCollider2D>().enabled = true;
            questionsAnswered = 0;
        }
    }

    /// <summary>
    /// When player collides with the door, the level is being changes
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            levelMenuController.UnlockLevel(SceneManager.GetActiveScene().buildIndex);
            fadeLevel.Fade();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
