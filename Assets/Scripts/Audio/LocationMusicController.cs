using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMusicController : MonoBehaviour
{

    private FMOD.Studio.EventInstance _elijahEvent;
    private FMOD.Studio.EventInstance _piperEvent;
    private FMOD.Studio.EventInstance _uniEvent;
    // Start is called before the first frame update
    void Start()
    {
        // if (location is elijah's apartment)
        _elijahEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/E-Apartment Music");
        // _elijahEvent.start();
        // same for other locations for events listed above
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
