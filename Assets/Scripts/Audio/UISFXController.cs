using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISFXController : MonoBehaviour
{
    private FMOD.Studio.EventInstance _confirmEvent;
    // Start is called before the first frame update
    void Start()
    {
        _confirmEvent = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Confirm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _confirmEvent.start();
    }
}
