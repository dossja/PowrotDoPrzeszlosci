using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// JSON cannot work with polish letters. According to question ID, the correct question text is being taken.
/// </summary>
public class QuestionText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questionText;

    public void Setup(int id)
    {
        if (id == 0)
            questionText.text = "W którym roku odbył się chrzest Polski?";
        else if (id == 1)
            questionText.text = "W którym roku odbył się zjazd Gnieźnieński?";
        else if (id == 2)
            questionText.text = "W którym roku zmarł Bolesław Krzywousty?";
        else if (id == 3)
            questionText.text = "W którym roku sprowadzono krzyżaków do Polski?";
        else if (id == 4)
            questionText.text = "W którym roku odbyła się bitwa pod Płowcami?";
        else if (id == 5)
            questionText.text = "W którym roku odbyła się bitwa pod Grunwaldem?";
        else if (id == 6)
            questionText.text = "W którym roku uchwalono Konstytucję 3 maja?";
        else if (id == 7)
            questionText.text = "W którym roku wybuchła I Wojna Światowa?";
        else if (id == 8)
            questionText.text = "W którym roku Karol Wojtyła został wybrany papieżem?";
    }
}
