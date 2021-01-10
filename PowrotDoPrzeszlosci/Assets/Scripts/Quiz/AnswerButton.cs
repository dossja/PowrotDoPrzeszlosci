using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class for AnswerButton in quiz
/// </summary>
public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI answerText;

    [SerializeField]
    private Button button;

    [SerializeField]
    private QuestionData questionData;

    private string correctAnswer;

    /// <summary>
    /// Setups the buttons with answers.
    /// </summary>
    /// <param name="answer">The answer.</param>
    /// <param name="correctAnswer">The correct answer.</param>
    public void Setup(string answer, string correctAnswer)
    {
        answerText.text = answer;
        this.correctAnswer = correctAnswer;
    }

    /// <summary>
    /// Checks the validity and changes button color into correct one.
    /// </summary>
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

    /// <summary>
    /// Disables the button.
    /// </summary>
    public void DisableButton()
    {
        button.interactable = false;
    }    
}
