using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI answerText;

    private string correctAnswer;

    [SerializeField]
    private Button button;


    public QuestionData questionData;
    public int questionId;

    public void Setup(string answer, string correctAnswer, int id)
    {
        answerText.text = answer;
        this.correctAnswer = correctAnswer;
        questionId = id;
    }

    public void CheckingValidity()
    {
        Image colorBlock = button.GetComponent<Image>();
        if (correctAnswer == answerText.text)
        {
            colorBlock.color = new Color(0.0f, 1.0f, 0.0f, 0.3f);
            //Adding points
        }
        else
        {
            colorBlock.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        }

        questionData.DisableButtons();
        questionData.PlayerAnswered(questionId, answerText.text);
    }

    public void DisableButton()
    {
        button.interactable = false;
    }    
}
