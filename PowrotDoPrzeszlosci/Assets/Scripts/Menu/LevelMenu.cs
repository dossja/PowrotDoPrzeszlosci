using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelButtons;

    private void Start()
    {
        LoadLevelData();
    }

    public void LoadLevelData()
    {
        // Load data from json. If true, then enable

        // Hardcoded for now
        levelButtons[0].GetComponent<Button>().enabled = true;
        levelButtons[1].GetComponent<Button>().enabled = true;
        levelButtons[2].GetComponent<Button>().enabled = false;
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
