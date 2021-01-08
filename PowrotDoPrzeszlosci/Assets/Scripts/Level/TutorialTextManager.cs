using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextManager : MonoBehaviour
{
    private Queue<string> titles;
    private Queue<string> texts;
    [SerializeField]
    private GameObject tutorialBox;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI textText;

    private void Start()
    {
        titles = new Queue<string>();
        texts = new Queue<string>();
    }

    public void StartTutorial(TutorialText tutorialText)
    {
        Debug.Log("Started ");

        titles.Clear();
        texts.Clear();

        foreach(string title in tutorialText.title)
        {
            titles.Enqueue(title);
        }

        foreach (string text in tutorialText.text)
        {
            texts.Enqueue(text);
        }

        ShowNextTip();
    }

    public void ShowNextTip()
    {
        if (titles.Count == 0 && texts.Count==0)
        {
            HideTutorialBox();
            return;
        }

        string title = titles.Dequeue();
        string text = texts.Dequeue();

        titleText.text = title;
        textText.text = text;
    }

    void HideTutorialBox()
    {
        Debug.Log("END");
        tutorialBox.SetActive(false);
    }
}
