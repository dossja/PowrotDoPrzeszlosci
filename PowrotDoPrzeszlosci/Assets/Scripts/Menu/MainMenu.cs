using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // New game ->  Load first level (Scene with ID 1)
    public void PlayNewGame()
    {
        SceneManager.LoadScene(1);
    }

    // Continue game ->  Load level with saved ID
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Wyjscie z gry!");
        Application.Quit();
    }
}
