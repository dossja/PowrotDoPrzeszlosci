using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AchievementsQuestion : MonoBehaviour
{
    [SerializeField]
    private QuestionsController questionsController;
    private QuestionsStructure questionsStructure;

    private Question questionData;

    [SerializeField]
    private QuestionText question;
    [SerializeField]
    private AnswerText answerPlayer;
    [SerializeField]
    private AnswerText answerCorrect;

    private void Start()
    {
        questionsStructure = questionsController.GetData();
    }

    public void SetupQuestion(int id)
    {
        questionsStructure = questionsController.GetData();
        Debug.Log("AchievementsQuestion");
        Debug.Log(questionsStructure);

        foreach (Question i in questionsStructure.Questions)
        {
            if (i.id == id)
                questionData = i;
        }
        

        question.Setup(id);
        answerPlayer.Setup(questionData.playerAnswer);
        answerCorrect.Setup(questionData.correctAnswer);
    }

}
