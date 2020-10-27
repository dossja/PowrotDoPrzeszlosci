using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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

    public void Start()
    {
        audioMixer.GetFloat("volume", out value);
        sliderMaster.value = value;

        sliderMusic.value = value;
        sliderSoundEffects.value = value;
    }

    public void SetVolumeMaster(float volume)
    {
        if (volume == 0)
            audioMixer.SetFloat("volume", -80);
        else
            audioMixer.SetFloat("volume", volume);

        if (sliderMusic.value > volume)
            sliderMusic.value = volume;

        if (sliderSoundEffects.value > volume)
            sliderSoundEffects.value = volume;
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.GetFloat("volume", out value);
        if (volume == 0)
            audioMixer.SetFloat("musicVolume", -80);
        else if (volume < value)
            audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetVolumeSoundEffects(float volume)
    {
        audioMixer.GetFloat("volume", out value);

        if (volume == 0)
            audioMixer.SetFloat("soundEffectsVolume", -80);
        else if (volume < value)
            audioMixer.SetFloat("soundEffectsVolume", volume);
    }
}
