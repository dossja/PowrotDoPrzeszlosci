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

    private AnswerData answerData;

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void CheckingValidity()
    {
        Image colorBlock = button.GetComponent<Image>();
        if (answerData.isCorrect)
        {
            colorBlock.color = new Color(0.0f, 1.0f, 0.0f, 0.3f);
            //Adding points
        }
        else
        {
            colorBlock.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        }

        //Script for stopping
    }
}
