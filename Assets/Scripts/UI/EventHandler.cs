using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    
    [SerializeField] private Button livingRoom;
    [SerializeField] private Button kitchen;
    [SerializeField] private Button bedroom;

    //Living Room
    [SerializeField] private GameObject livingRoomOptions;

    [SerializeField] private Button storage;
    [SerializeField] private GameObject storagePanel;

    private static bool isStorageOpen = false;

    [SerializeField] private Button statues;
    [SerializeField] private GameObject statuesPanel;

    private static bool isStatuesOpen = false;

    //Kitchen
    [SerializeField] private GameObject kitchenOptions;

    [SerializeField] private Button fridge;
    [SerializeField] private GameObject fridgePanel;

    private static bool isFridgeOpen = false;

    //Bedroom
    [SerializeField] private GameObject bedroomOptions;

    [SerializeField] private Button bed;

    [SerializeField] private Button closet;
    [SerializeField] private GameObject closetPanel;

    private static bool isClosetOpen = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        livingRoom.onClick.AddListener(LivingRoom);
        kitchen.onClick.AddListener(Kitchen);
        bedroom.onClick.AddListener(Bedroom);

        storage.onClick.AddListener(Storage);
        statues.onClick.AddListener(Statues);

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
        isStatuesOpen = false;
        isClosetOpen = false;
        storagePanel.SetActive(false);
        statuesPanel.SetActive(false);
        closetPanel.SetActive(false);
    }

    private void Bedroom(){
        livingRoomOptions.SetActive(false);
        kitchenOptions.SetActive(false);
        bedroomOptions.SetActive(true);
        isStorageOpen = false;
        isStatuesOpen = false;
        isFridgeOpen = false;
        storagePanel.SetActive(false);
        statuesPanel.SetActive(false);
        fridgePanel.SetActive(false);
    }

    private void Storage(){
        isStorageOpen =!isStorageOpen;
        storagePanel.SetActive(isStorageOpen);
        if (isStorageOpen){
            statuesPanel.SetActive(false);
            closetPanel.SetActive(false);
            fridgePanel.SetActive(false);
            isStatuesOpen = false;
            isClosetOpen = false;
            isFridgeOpen = false;
        }
    }

    private void Statues(){
        isStatuesOpen =!isStatuesOpen;
        statuesPanel.SetActive(isStatuesOpen);
        if (isStatuesOpen){
            storagePanel.SetActive(false);
            closetPanel.SetActive(false);
            fridgePanel.SetActive(false);
            isStorageOpen = false;
            isClosetOpen = false;
            isFridgeOpen = false;
        }
    }

    private void Fridge(){
        isFridgeOpen =!isFridgeOpen;
        fridgePanel.SetActive(isFridgeOpen);
        if (isFridgeOpen){
            storagePanel.SetActive(false);
            statuesPanel.SetActive(false);
            closetPanel.SetActive(false);
            isStorageOpen = false;
            isStatuesOpen = false;
            isClosetOpen = false;
        }
    }

    private void Bed(){
        //If night time, then sleep and make it day
    }

    private void Closet(){
        isClosetOpen =!isClosetOpen;
        closetPanel.SetActive(isClosetOpen);
        if (isClosetOpen){
            storagePanel.SetActive(false);
            statuesPanel.SetActive(false);
            fridgePanel.SetActive(false);
            isStorageOpen = false;
            isStatuesOpen = false;
            isFridgeOpen = false;
        }
    }

    
}
