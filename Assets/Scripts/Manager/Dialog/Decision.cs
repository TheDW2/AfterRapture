using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    public object element;
    public void Decide()
    {
        DialogManager.SetDecision(element);
    }
}
