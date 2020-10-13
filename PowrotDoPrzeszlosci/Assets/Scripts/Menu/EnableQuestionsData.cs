using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class EnableQuestionsData : MonoBehaviour
{
    private QuestionGameData[] questionGameData;
    private QuestionGameData questionData;

    [SerializeField]
    private GameObject[] questionButtons;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private void Start()
    {
        LoadData();
        SetupQuestionButtons();
    }

    public void SetupQuestionButtons()
    {
        int points = 0;
        for(int i = 0; i < 9; i++)
        {
            if (questionGameData[i].playerAnswer != "none")
            {
                if (questionGameData[i].playerAnswer == questionGameData[i].correctAnswer)
                {
                    Activate(questionButtons[i], true);
                    points += 1;
                }
                else
                    Activate(questionButtons[i], false);
            }
                
            else
                questionButtons[i].GetComponent<Button>().enabled = false;
        }
        Debug.Log(points);
        pointsText.text = points.ToString();
    }

    public void LoadData()
    {
        string json = ReadFromFile();

        questionGameData = JsonHelper.FromJson<QuestionGameData>(json);
    }

    private string ReadFromFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.json");

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();

                return json;
            }
        }
        else
        {
            filePath = Application.persistentDataPath + "data.json";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();

                    return json;
                }
            }
            else
                Debug.LogWarning("File not found!");
        }
        return "";
    }

    private void Activate(GameObject gameObject, bool state)
    {
        ColorBlock colorBlock = gameObject.GetComponent<Button>().colors;

        if (state)
        {
            colorBlock.normalColor = new Color(0.0f, 1.0f, 0.0f, 0.3f);
        }
        else
        {
            colorBlock.normalColor = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        }
        gameObject.GetComponent<Button>().colors = colorBlock;
    }
}
