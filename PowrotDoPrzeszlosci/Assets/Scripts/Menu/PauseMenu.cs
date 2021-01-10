using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for pausing the game when in Pause Menu and for implementing basic pause menu buttons.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Resumes the game by changing the timeScale.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Returns the to main menu.
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
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
