using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    
    public CollectiblesList c;
    public GameObject gameObjects;

    private GameObject holding;
    
    
    void Update() {
        if (InvManager.holding > 0 && Input.GetKeyDown(KeyCode.Q)) {
            holding = c.collectableItems[InvManager.holding];
            GameObject temp = Instantiate(holding, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0), holding.transform.rotation);
            temp.transform.parent = gameObjects.transform;
            temp.name = holding.name;
            InvManager.inventory[InvManager.onSlot] = 0;
        }
    }
}
