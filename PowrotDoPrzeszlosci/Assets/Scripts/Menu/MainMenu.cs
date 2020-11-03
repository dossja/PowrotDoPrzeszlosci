using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelMenuController levelMenuController;
    [SerializeField]
    private QuestionsController questionsController;

    public void PlayNewGame()
    {
        questionsController.DeleteAnswers();
        levelMenuController.DeleteLevels();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Wyjscie z gry!");
        Application.Quit();
    }
}
