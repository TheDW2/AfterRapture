using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite closed;
    public Sprite open;

    public SpriteRenderer spriteRenderer;


    //When the door is opened, it will stay in place, but the actual sprite gets bigger, seeming like the door has moved to the left/right.
    //Allign the two sprites and check for the x position for the opened door. Set the offset variable to that.
    //Sorry if I'm confusing, ask me if you don't understand.
    public float offset;

    void Start() {
        spriteRenderer.sprite = closed;
    }

    void OnMouseOver()
    {
        //If sprite clicked
        if (InvManager.holding == 1 && Input.GetMouseButtonDown(0)) {
            if (spriteRenderer.sprite == closed) {
                transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
                spriteRenderer.sprite = open;
                InvManager.inventory[InvManager.onSlot] = 0;
            }
        }
    }
}
