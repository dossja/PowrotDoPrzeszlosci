using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Structure for list of questions.
/// </summary>
[Serializable]
public class QuestionsStructure
{
    public List<Question> Questions;
}

/// <summary>
/// Question structure according to JSON input.
/// </summary>
[Serializable]
public class Question
{
    public int id;
    public string question;

    public string playerAnswer;

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public string correctAnswer;
}
