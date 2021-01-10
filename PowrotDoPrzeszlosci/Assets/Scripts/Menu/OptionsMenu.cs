using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Class for changing the volume in game in OptionsMenu
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    float value;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider sliderMaster;
    [SerializeField]
    private Slider sliderMusic;
    [SerializeField]
    private Slider sliderSoundEffects;

    /// <summary>
    /// Set ups the game volume from PlayerPrefabs (in order to remember it between sessions).
    /// </summary>
    public void Start()
    {
        value = PlayerPrefs.GetFloat("volume");

        sliderMaster.value = value;

        sliderMusic.value = value;
        sliderSoundEffects.value = value;
    }

    /// <summary>
    /// Sets the master volume.
    /// </summary>
    /// <param name="volume">The volume.</param>
    public void SetVolumeMaster(float volume)
    {
        if (volume == 0)
            audioMixer.SetFloat("volume", -80);
        else
            audioMixer.SetFloat("volume", volume);

        audioMixer.GetFloat("volume", out value);
        PlayerPrefs.SetFloat("volume", value);

        if (sliderMusic.value > volume)
            sliderMusic.value = volume;

        if (sliderSoundEffects.value > volume)
            sliderSoundEffects.value = volume;
    }

    /// <summary>
    /// Sets the music volume.
    /// </summary>
    /// <param name="volume">The volume.</param>
    public void SetVolumeMusic(float volume)
    {
        value = PlayerPrefs.GetFloat("volume");

        if (volume == 0)
            audioMixer.SetFloat("musicVolume", -80);
        else if (volume < value)
            audioMixer.SetFloat("musicVolume", volume);

        audioMixer.GetFloat("musicVolume", out value);
        PlayerPrefs.SetFloat("musicVolume", value);
    }

    /// <summary>
    /// Sets the sound effects volume.
    /// </summary>
    /// <param name="volume">The volume.</param>
    public void SetVolumeSoundEffects(float volume)
    {
        value = PlayerPrefs.GetFloat("volume");

        if (volume == 0)
            audioMixer.SetFloat("soundEffectsVolume", -80);
        else if (volume < value)
            audioMixer.SetFloat("soundEffectsVolume", volume);

        audioMixer.GetFloat("soundEffectsVolume", out value);
        PlayerPrefs.SetFloat("soundEffectsVolume", value);
    }
}
