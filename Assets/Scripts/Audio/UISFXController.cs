using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISFXController : MonoBehaviour
{
    private FMOD.Studio.EventInstance _confirmEvent;
    private FMOD.Studio.EventInstance _pauseEvent;
    // Start is called before the first frame update
    void Start()
    {
        _confirmEvent = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Confirm");
        _pauseEvent = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _confirmEvent.start();
    }

    public void OnPauseClick()
    {
        _pauseEvent.start();
    }
}
