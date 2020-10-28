using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelButtons;

    [SerializeField]
    private LevelMenuController levelMenuController;
    private LevelDataStructure levelDataStructure;

    [SerializeField]
    private int levelId;

    private void Start()
    {
        levelDataStructure = levelMenuController.GetData();
        SetupLevel();
    }

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

    private void Enable(GameObject gameObject, bool state)
    {
        gameObject.GetComponent<Button>().enabled = state;
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
