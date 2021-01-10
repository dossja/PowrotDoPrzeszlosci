using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Close Quiz showes "Kontynuuj" button after answering quiz
/// </summary>
public class CloseQuiz : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;

    /// <summary>
    /// Changes gameobject active state
    /// </summary>
    public void QuestionAnsweredPanel()
    {
        gameObject.active = true;
    }
}
