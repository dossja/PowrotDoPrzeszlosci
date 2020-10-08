using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQuiz : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;

    public void QuestionAnsweredPanel()
    {
        gameObject.active = true;
    }
}
