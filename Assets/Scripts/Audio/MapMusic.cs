using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMusic : MonoBehaviour
{
    public GameObject mapMusicController;
    public GameObject dayIndicatorIcon;
    // Start is called before the first frame update
    void Start()
    {

        if (dayIndicatorIcon.GetComponent<Image>().sprite.name == "sun")
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Time of Day", 0);
        }

        if (dayIndicatorIcon.GetComponent<Image>().sprite.name == "moon")
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Time of Day", 1);
        }

        if (GameObject.Find("MusicController") == null)
        {
            mapMusicController.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
