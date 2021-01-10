using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that is used in the Canvas GameObject in order to trigger the tutorial in first scene.
/// </summary>
public class TutorialTextTrigger : MonoBehaviour
{
    public TutorialText tutorialText;

    /// <summary>
    /// At the level start, the tutorial is being triggered
    /// </summary>
    private void Start()
    {
        TriggerTutorial();   
    }

    /// <summary>
    /// Finds TutorialTextManager object and triggers the tutorial.
    /// And sends tutorialText for it to use.
    /// </summary>
    private void TriggerTutorial()
    {
        FindObjectOfType<TutorialTextManager>().StartTutorial(tutorialText);
    }
}
