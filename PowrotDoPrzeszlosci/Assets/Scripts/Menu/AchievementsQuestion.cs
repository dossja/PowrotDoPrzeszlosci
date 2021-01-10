using UnityEngine;

/// <summary>
/// Class for sending questions data into correct fields in AchievementMenu.
/// </summary>
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

    /// <summary>
    /// Gets question data at start
    /// </summary>
    private void Start()
    {
        questionsStructure = questionsController.GetData();
    }

    /// <summary>
    /// Setups the question parts with this id into correct places in menu.
    /// </summary>
    /// <param name="id">The id.</param>
    public void SetupQuestion(int id)
    {
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
