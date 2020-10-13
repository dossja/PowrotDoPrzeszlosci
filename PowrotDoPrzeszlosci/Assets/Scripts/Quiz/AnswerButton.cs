using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI answerText;

    [SerializeField]
    private Button button;

    [SerializeField]
    private QuestionData questionData;

    private string correctAnswer;

    public void Setup(string answer, string correctAnswer)
    {
        answerText.text = answer;
        this.correctAnswer = correctAnswer;
    }

    public void CheckingValidity()
    {
        Image colorBlock = button.GetComponent<Image>();
        if (correctAnswer == answerText.text)
        {
            colorBlock.color = new Color(0.0f, 1.0f, 0.0f, 0.3f);
        }
        else
        {
            colorBlock.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        }

        questionData.DisableButtons();
        questionData.PlayerAnswered(answerText.text);
    }

    public void DisableButton()
    {
        button.interactable = false;
    }    
}
