using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for setting up LevelDataMenu
/// </summary>
public class LevelData : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelButtons;

    [SerializeField]
    private LevelMenuController levelMenuController;
    private LevelDataStructure levelDataStructure;

    [SerializeField]
    private int levelId;

    /// <summary>
    /// Set ups the level data at start of this part of menu.
    /// </summary>
    private void Start()
    {
        levelDataStructure = levelMenuController.GetData();
        SetupLevel();
    }

    /// <summary>
    /// Setups the level buttons.
    /// </summary>
    private void SetupLevel()
    {
        foreach(LevelState i in levelDataStructure.Levels)
        {
            if (i.enabled == true)
                Enable(levelButtons[i.id], true);
            else
                Enable(levelButtons[i.id], false);
        }
    }

    /// <summary>
    /// Enables the level buttons.
    /// </summary>
    /// <param name="gameObject">The button game object.</param>
    /// <param name="state">Information if button should be enabled.</param>
    private void Enable(GameObject gameObject, bool state)
    {
        gameObject.GetComponent<Button>().enabled = state;
    }

    /// <summary>
    /// Loads the level.
    /// </summary>
    /// <param name="number">The number of the level.</param>
    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
