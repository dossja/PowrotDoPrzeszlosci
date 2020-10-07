using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;

    [SerializeField]
    private int numberOfQuestions = 5;

    [SerializeField]
    private GameObject[] questions;

    [SerializeField]
    private bool[] questionStates;


    private void Start()
    {
        SetPoints();
        for(int i = 0; i < numberOfQuestions; i++)
        {
            Activate(questions[i], questionStates[i]);
        }
    }

    public void LoadQuestion(int number)
    {
        Debug.Log(number);
    }

    public void DeleteAchievements()
    {
        for(int i = 0; i < numberOfQuestions; i++)
        {
            questionStates[i] = false;

            Activate(questions[i], questionStates[i]);
        }
    }

    private void SetPoints()
    {
        Debug.Log(pointsText.text);
        int points = 0;
        for(int i = 0; i < numberOfQuestions; i++)
        {
            if(questionStates[i])
            {
                points += 1;
            }
        }
        Debug.Log(points);
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