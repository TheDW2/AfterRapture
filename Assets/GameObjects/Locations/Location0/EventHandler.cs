using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler0 : MonoBehaviour
{
    
    

    

    [SerializeField] private Button bed;

    [SerializeField] private Button closet;
    [SerializeField] private GameObject closetPanel;

    public static bool isClosetOpen = false;

    private SaveFile _saveFile;
    
    
    // Start is called before the first frame update
    void Start()
    {
        

        bed.onClick.AddListener(Bed);
        closet.onClick.AddListener(Closet);
    }

    
    private void Bed(){

        _saveFile = new SaveFile();
        
        isClosetOpen = false;
        closetPanel.SetActive(false);
        
        if (_saveFile._playerSave._timeCycle == TimeCycle.Night){
            _saveFile._playerSave._timeCycle = TimeCycle.Day;
        } else {
            Debug.LogWarning("You cannot sleep during day");
        }
    }

    private void Closet(){
        isClosetOpen =!isClosetOpen;
        closetPanel.SetActive(isClosetOpen);
    }

    
}