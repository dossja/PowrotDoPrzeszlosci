using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for loading the Pause Menu with changing the timeScale to pause level.
/// </summary>
public class LoadPauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
}
