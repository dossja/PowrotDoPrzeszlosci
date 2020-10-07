using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData: MonoBehaviour
{
    public string questionText;
    public AnswerData[] answers;

    public QuestionText question;
    public AnswerButton answer1;
    public AnswerButton answer2;
    public AnswerButton answer3;
    public AnswerButton answer4;

    private void Start()
    {
        answer1.Setup(answers[0]);
        answer2.Setup(answers[1]);
        answer3.Setup(answers[2]);
        answer4.Setup(answers[3]);

        question.Setup(questionText);
    }
}
