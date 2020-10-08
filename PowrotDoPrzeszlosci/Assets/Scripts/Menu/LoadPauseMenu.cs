using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
}
