using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for MainMenu methods, that are more complicated then those which can be used in Editor.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LevelMenuController levelMenuController;
    [SerializeField]
    private QuestionsController questionsController;

    /// <summary>
    /// Plays the new game.
    /// </summary>
    public void PlayNewGame()
    {
        questionsController.DeleteAnswers();
        levelMenuController.DeleteLevels();
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Wyjscie z gry!");
        Application.Quit();
    }
}
