using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    void Start()
    {
        //set volume to saved value
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        
        AudioMixerManager.instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value;
    
        AudioMixerManager.instance.UpdateMixerVolume();
    }
}
