using UnityEngine;

/// <summary>
/// TutorialText class, holdes place for titles and texts to input in Editor.
/// </summary>
[System.Serializable]
public class TutorialText
{
    public string[] title;

    [TextArea(2, 6)]
    public string[] text;
}
