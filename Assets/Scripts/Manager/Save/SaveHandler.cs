using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    public static SaveHandler instance;
    void Awake()
    {
        instance = this;
        SaveManager.Init();
    }
}

