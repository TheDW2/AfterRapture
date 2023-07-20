using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Get the active scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);

        // Switch initial music depending on scene
        switch (scene.name)
        {
            case "0. Mainmenu":
                FMODUnity.RuntimeManager.PlayOneShot("event:/Music/Menu");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
