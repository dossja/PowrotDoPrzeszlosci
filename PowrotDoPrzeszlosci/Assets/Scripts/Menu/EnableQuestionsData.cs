using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class EnableQuestionsData : MonoBehaviour
{
    [SerializeField]
    private QuestionsController questionsController;
    private QuestionsStructure questionsStructure;

    [SerializeField]
    private GameObject[] questionButtons;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private void Start()
    {
        questionsStructure = questionsController.GetData();
        SetupQuestionButtons();
    }

    public void SetupQuestionButtons()
    {
        int points = 0;

        foreach (Question i in questionsStructure.Questions)
        {
            if (i.playerAnswer != "none")
            {
                if (i.playerAnswer == i.correctAnswer)
                {
                    Activate(questionButtons[i.id], true);
                    points += 1;
                }
                else
                    Activate(questionButtons[i.id], false);
            }
                
            else
                questionButtons[i.id].GetComponent<Button>().enabled = false;
        }

        pointsText.text = points.ToString();
    }

    private void Activate(GameObject gameObject, bool state)
    {
        ColorBlock colorBlock = gameObject.GetComponent<Button>().colors;

        if (state)
        {
            colorBlock.normalColor = new Color(0.0f, 1.0f, 0.0f, 0.3f);
        }
        else
        {
            colorBlock.normalColor = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        }
        gameObject.GetComponent<Button>().colors = colorBlock;
    }
}
