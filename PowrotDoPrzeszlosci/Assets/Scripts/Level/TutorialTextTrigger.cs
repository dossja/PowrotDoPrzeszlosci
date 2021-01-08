using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextTrigger : MonoBehaviour
{
    public TutorialText tutorialText;

    private void Start()
    {
        TriggerTutorial();   
    }

    private void TriggerTutorial()
    {
        FindObjectOfType<TutorialTextManager>().StartTutorial(tutorialText);
    }
}
