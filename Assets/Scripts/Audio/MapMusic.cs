using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMusic : MonoBehaviour
{
    public GameObject mapMusicController;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MusicController")  == null)
        {
            mapMusicController.SetActive(true);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
