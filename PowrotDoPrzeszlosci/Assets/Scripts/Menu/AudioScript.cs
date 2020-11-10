using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    float value;
    [SerializeField]
    private AudioMixer audioMixer;
    // Start is called before the first frame update
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
