using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class SetVolume : MonoBehaviour
{
    public string Name;
    public Slider slider;

    public AudioMixer mixer;
    void Start()
    {
        if (Name == "master")
        {
        slider.value = PlayerPrefs.GetFloat("MasterVol", 0.75f);
        }
        if (Name == "music")
        {
            slider.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        }
        if (Name == "sounds")
        {
            slider.value = PlayerPrefs.GetFloat("SoundVol", 0.75f);
        }

    }
    public void SetLevel(float sliderValue)
    {
        if (Name == "master")
        {
            mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue)*20);
            PlayerPrefs.SetFloat("MasterVol", sliderValue);
        }
        if (Name == "music")
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("MusicVol", sliderValue);
        }
        if (Name == "sounds")
        {
            mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("SoundVol", sliderValue);
        }

    }
}
