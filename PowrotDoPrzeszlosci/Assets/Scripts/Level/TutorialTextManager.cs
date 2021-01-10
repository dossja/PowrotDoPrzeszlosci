using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manager for tutorial text
/// </summary>
public class TutorialTextManager : MonoBehaviour
{
    private Queue<string> titles;
    private Queue<string> texts;
    [SerializeField]
    private GameObject tutorialBox;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI textText;

    /// <summary>
    /// Creates new empty Queues for texts and titles
    /// </summary>
    private void Start()
    {
        titles = new Queue<string>();
        texts = new Queue<string>();
    }

    /// <summary>
    /// Starts the tutorial (TutorialTextTrigger triggers it).
    /// </summary>
    /// <param name="tutorialText">The tutorial text.</param>
    public void StartTutorial(TutorialText tutorialText)
    {
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

    /// <summary>
    /// Shows the next tip and hides tutorial when there is no more text in the Queue.
    /// </summary>
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

    /// <summary>
    /// Deactivates the tutorial box.
    /// </summary>
    void HideTutorialBox()
    {
        tutorialBox.SetActive(false);
    }
}
