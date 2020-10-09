using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class QuestionData: MonoBehaviour
{
    public string questionText;

    private QuestionGameData[] questionGameData;
    private QuestionGameData questionData;

    [SerializeField]
    private CloseQuiz closeQuiz;

    [SerializeField]
    private QuestionText question;
    [SerializeField]
    private AnswerButton answer1;
    [SerializeField]
    private AnswerButton answer2;
    [SerializeField]
    private AnswerButton answer3;
    [SerializeField]
    private AnswerButton answer4;
    
    [SerializeField]
    private int questionId;

    private bool buttonsDisabled = false;
    private int wait = 0;

    private void Start()
    {
        LoadData();
        SetupQuestion(questionId);
    }

    public void SetupQuestionMenu(int id)
    {
        //Different setup
    }

    public void SetupQuestion(int id)
    {
        questionData = questionGameData[id];
        answer1.Setup(questionData.answer1, questionData.correctAnswer, id);
        answer2.Setup(questionData.answer2, questionData.correctAnswer, id);
        answer3.Setup(questionData.answer3, questionData.correctAnswer, id);
        answer4.Setup(questionData.answer4, questionData.correctAnswer, id);

        question.Setup(id);
    }

    public void PlayerAnswered(int id, string answer)
    {
        questionData = questionGameData[id];

        questionGameData[id].playerAnswer = answer;

        Debug.Log(questionGameData[id].playerAnswer);

        SaveData();
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

    public void SaveData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.json");
        string dataToSave = JsonHelper.ToJson(questionGameData, true);

        File.WriteAllText(filePath, dataToSave);
    }

    public void DisableButtons()
    {
        answer1.DisableButton();
        answer2.DisableButton();
        answer3.DisableButton();
        answer4.DisableButton();

        buttonsDisabled = true;
    }

    public void Update()
    {
        if(buttonsDisabled)
        {
            wait += 1;
        }

        if(wait == 240)
        {
            closeQuiz.QuestionAnsweredPanel();
            buttonsDisabled = false;
            wait = 0;
        }
    }
}
