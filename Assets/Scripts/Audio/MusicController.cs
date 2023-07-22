using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    // Start is called before the first frame update
    void Start()
    {
        instance.release();
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/BG Music");
        // Get the active scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Time Of Day", 0);

        // Switch initial music depending on scene
        switch (scene.name)
        {
            case "2. MapScene":
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Location", 0);
                instance.start();
                break;
            case "3. LocationScene":
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Location", 1);
                instance.start();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
