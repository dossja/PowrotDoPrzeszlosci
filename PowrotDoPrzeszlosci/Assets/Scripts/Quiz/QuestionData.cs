using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData: MonoBehaviour
{
    public string questionText;
    public AnswerData[] answers;

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

    private bool buttonsDisabled = false;
    private int wait = 0;

    private void Start()
    {
        answer1.Setup(answers[0]);
        answer2.Setup(answers[1]);
        answer3.Setup(answers[2]);
        answer4.Setup(answers[3]);

        question.Setup(questionText);
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
