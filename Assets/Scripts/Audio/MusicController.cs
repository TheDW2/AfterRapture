using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private FMOD.Studio.EventInstance _musicEvent;
    private FMOD.Studio.EventInstance _mapMusicEvent;
 
   
    void Start()
    {
        DontDestroyOnLoad(this);
        _musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Menu");
        _mapMusicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Map Music");
        _musicEvent.start();
        //_musicEvent.getParameter("Exit", out _exitParameter);

    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "2. MapScene") && (_musicEvent.isValid() == true))
        {
            //Debug.Log("I am changing a parameter!!!!");


            _musicEvent.setParameterByName("MenuToMap", 1);
            //Debug.Log(_musicEvent.setParameterByName("MenuToMap", 1));
            //Debug.Log(_musicEvent.isValid());
        } else if (SceneManager.GetActiveScene().name == "2. MapScene")
        {
            _mapMusicEvent.start();
            Debug.Log("map music should start");
        }

        if (SceneManager.GetActiveScene().name == "3. LocationScene")
        {
            _musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //Destroy(this.gameObject);
            //Debug.Log("I am being destroyed?");
            
        }
    }
}
