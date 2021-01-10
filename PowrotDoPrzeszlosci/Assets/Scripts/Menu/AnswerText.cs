using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class to display answers in questions
/// </summary>
public class AnswerText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI answerText;

    /// <summary>
    /// Setups the text.
    /// </summary>
    /// <param name="text">The text.</param>
    public void Setup(string text)
    {
        answerText.text = text;
    }
}
