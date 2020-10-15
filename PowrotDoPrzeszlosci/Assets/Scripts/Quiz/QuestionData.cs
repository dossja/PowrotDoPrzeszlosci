using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class QuestionData: MonoBehaviour
{
    public string questionText;

    [SerializeField]
    private QuestionsController questionsController;
    private QuestionsStructure questionsStructure;

    private Question questionData;

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
        questionsStructure = questionsController.GetData();
        SetupQuestion(questionId);
    }

    public void SetupQuestion(int id)
    {
        foreach (Question i in questionsStructure.Questions)
        {
            if (i.id == id)
                questionData = i;
        }

        answer1.Setup(questionData.answer1, questionData.correctAnswer);
        answer2.Setup(questionData.answer2, questionData.correctAnswer);
        answer3.Setup(questionData.answer3, questionData.correctAnswer);
        answer4.Setup(questionData.answer4, questionData.correctAnswer);

        question.Setup(id);
    }

    public void PlayerAnswered(string answer)
    {
        questionData.playerAnswer = answer;

        questionsController.SaveData(questionsStructure);
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
