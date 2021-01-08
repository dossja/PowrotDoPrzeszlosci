using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        questionsAnswered = 0;
    }

    public void questionAnswered()
    {
        questionsAnswered += 1;
    }


    void Update()
    {
        if(questionsAnswered == 3)
        {
            light.SetActive(true);
            questionsAnswered = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            levelMenuController.UnlockLevel(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().buildIndex == 3)
                SceneManager.LoadScene(0);
            else
            {
                fadeLevel.Fade();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
