using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class SaveSlot: MonoBehaviour
{
    [SerializeField] private Button _saveSlotBtn;
    [SerializeField] private TextMeshProUGUI _saveSlotDayType;
    [SerializeField] private TextMeshProUGUI _saveSlotHunger;
    [SerializeField] private TextMeshProUGUI _saveSlotEnergy;
    [SerializeField] private TextMeshProUGUI _saveSlotStoryProgress;
    [SerializeField] private TextMeshProUGUI _saveSlotNoSave;

    private SaveFile _saveFile;

    void Start()
    {
        _saveSlotBtn.onClick.AddListener(LoadSlot);
    }

    public void SetSaveFile(SaveFile _save)
    {
        _saveFile = _save;
        //set everything
    }

    private void LoadSlot()
    {
        if(_saveFile != null)
        {
            //load the game
        }
    }

}
