using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{

    private FMOD.Studio.VCA VCAController;
    public string VCAName;

    private Slider audioSlider;

    // Start is called before the first frame update
    void Start()
    {
        VCAController = FMODUnity.RuntimeManager.GetVCA("vca:/" + VCAName);
        audioSlider = GetComponent<Slider>();
    }

    public void SetVolume(float volume)
    {
        VCAController.setVolume(volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
