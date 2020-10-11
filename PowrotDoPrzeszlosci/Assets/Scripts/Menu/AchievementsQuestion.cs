using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AchievementsQuestion : MonoBehaviour
{
    private QuestionGameData[] questionGameData;
    private QuestionGameData questionData;

    [SerializeField]
    private QuestionText question;
    [SerializeField]
    private AnswerText answerPlayer;
    [SerializeField]
    private AnswerText answerCorrect;

    private void Start()
    {
        LoadData();
    }

    public void SetupQuestion(int id)
    {
        questionData = questionGameData[id];
        Debug.Log(id);

        question.Setup(id);
        answerPlayer.Setup(questionData.playerAnswer);
        answerCorrect.Setup(questionData.correctAnswer);
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
            Debug.LogWarning("File not found!");

        return "";
    }
}
