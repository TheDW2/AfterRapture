using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler0 : MonoBehaviour
{
    
    [SerializeField] private Button livingRoom;
    [SerializeField] private Button kitchen;
    [SerializeField] private Button bedroom;

    //Living Room
    [SerializeField] private GameObject livingRoomOptions;

    [SerializeField] private Button storage;
    [SerializeField] private GameObject storagePanel;

    public static bool isStorageOpen = false;

    //Kitchen
    [SerializeField] private GameObject kitchenOptions;

    [SerializeField] private Button fridge;
    [SerializeField] private GameObject fridgePanel;

    public static bool isFridgeOpen = false;

    //Bedroom
    [SerializeField] private GameObject bedroomOptions;

    [SerializeField] private Button bed;

    [SerializeField] private Button closet;
    [SerializeField] private GameObject closetPanel;

    public static bool isClosetOpen = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        livingRoom.onClick.AddListener(LivingRoom);
        kitchen.onClick.AddListener(Kitchen);
        bedroom.onClick.AddListener(Bedroom);

        storage.onClick.AddListener(Storage);

        fridge.onClick.AddListener(Fridge);

        bed.onClick.AddListener(Bed);
        closet.onClick.AddListener(Closet);
    }

    private void LivingRoom(){
        livingRoomOptions.SetActive(true);
        kitchenOptions.SetActive(false);
        bedroomOptions.SetActive(false);
        isFridgeOpen = false;
        isClosetOpen = false;
        fridgePanel.SetActive(false);
        closetPanel.SetActive(false);
    }

    private void Kitchen(){
        livingRoomOptions.SetActive(false);
        kitchenOptions.SetActive(true);
        bedroomOptions.SetActive(false);
        isStorageOpen = false;
        isClosetOpen = false;
        storagePanel.SetActive(false);
        closetPanel.SetActive(false);
    }

    private void Bedroom(){
        livingRoomOptions.SetActive(false);
        kitchenOptions.SetActive(false);
        bedroomOptions.SetActive(true);
        isStorageOpen = false;
        isFridgeOpen = false;
        storagePanel.SetActive(false);
        fridgePanel.SetActive(false);
    }

    private void Storage(){
        isStorageOpen =!isStorageOpen;
        storagePanel.SetActive(isStorageOpen);
        if (isStorageOpen){
            closetPanel.SetActive(false);
            fridgePanel.SetActive(false);
            isClosetOpen = false;
            isFridgeOpen = false;
        }
    }

    

    private void Fridge(){
        isFridgeOpen =!isFridgeOpen;
        fridgePanel.SetActive(isFridgeOpen);
        if (isFridgeOpen){
            storagePanel.SetActive(false);
            closetPanel.SetActive(false);
            isStorageOpen = false;
            isClosetOpen = false;
        }
    }

    private void Bed(){
        storagePanel.SetActive(false);
        closetPanel.SetActive(false);
        fridgePanel.SetActive(false);
        isStorageOpen = false;
        isFridgeOpen = false;
        //If night time, then sleep and make it day (idk how to do that)
        //Else, display a message saying that it's still day
    }

    private void Closet(){
        isClosetOpen =!isClosetOpen;
        closetPanel.SetActive(isClosetOpen);
        if (isClosetOpen){
            storagePanel.SetActive(false);
            fridgePanel.SetActive(false);
            isStorageOpen = false;
            isFridgeOpen = false;
        }
    }

    
}
