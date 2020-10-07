using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questionText;


    public void Setup(string data)
    {
        questionText.text = data;
    }
}
