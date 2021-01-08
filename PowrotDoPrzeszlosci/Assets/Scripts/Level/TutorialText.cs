using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialText
{
    public string[] title;

    [TextArea(2, 6)]
    public string[] text;
}
