using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Class for connecting AudioMixer with PlayerPrefabs
/// </summary>
public class AudioScript : MonoBehaviour
{
    float value;
    [SerializeField]
    private AudioMixer audioMixer;

    // Start is called before the first frame update
    /// <summary>
    /// Set ups volume fron PlayerPrefabs.
    /// </summary>
    void Start()
    {
        value = PlayerPrefs.GetFloat("volume");
        audioMixer.SetFloat("volume", value);

        value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("musicVolume", value);

        value = PlayerPrefs.GetFloat("soundEffectsVolume");
        audioMixer.SetFloat("soundEffectsVolume", value);
    }
}
