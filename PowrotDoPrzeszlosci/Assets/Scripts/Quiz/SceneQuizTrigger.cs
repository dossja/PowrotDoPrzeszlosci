using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SceneQuizTrigger is script that is being put on Question boards in game. It triggers the questions.
/// </summary>
public class SceneQuizTrigger : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject questionMenu;
    [SerializeField]
    private GameObject heartsUI;
    [SerializeField]
    private GameObject buttonUI;
    [SerializeField]
    private GameObject joystickUI;
    [SerializeField]
    private Button button;
    [SerializeField]
    private LevelEnd levelEnd;
    private bool entered;
    private GameObject board;

    /// <summary>
    /// Set up on start
    /// </summary>
    void Start()
    {
        board = this.gameObject;
        entered = false;
    }

    /// <summary>
    /// When player enters, then the question can be triggered.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.name == "Player")
        {
            entered = true;
        }
    }

    /// <summary>
    /// When player exits, then the question no longer can be triggered.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            entered = false;
        }
    }

    /// <summary>
    /// When the Action button is pressed, and question can be triggered.
    /// Then the UI is changed into question UI and board is removed.
    /// </summary>
    public void ButtonPressed()
    {
        if(entered)
        {
            heartsUI.SetActive(false);
            buttonUI.SetActive(false);
            joystickUI.SetActive(false);
            questionMenu.SetActive(true);
            button.gameObject.SetActive(false);
            levelEnd.QuestionAnswered();
            Time.timeScale = 0.0f;

            Destroy(board);
        }
    }
}
