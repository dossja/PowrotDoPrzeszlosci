using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI answerText;

    public void Setup(string text)
    {
        answerText.text = text;
    }
}
