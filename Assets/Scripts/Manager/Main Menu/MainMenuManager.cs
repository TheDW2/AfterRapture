using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private Button _backButton;

    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private GameObject _saveSlotPanel;

    [Header("Save Slot")]
    [SerializeField] private SaveSlot [] _saveSlotButtons;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _playButton.onClick.AddListener(PlayGame);
        _optionButton.onClick.AddListener(OpenOption);
        _exitButton.onClick.AddListener(QuitGame);
        _backButton.onClick.AddListener(CloseSaveSlot);
    }

    private void PlayGame()
    {
        _saveSlotPanel.SetActive(true);
    }

    private void CloseSaveSlot()
    {
        _saveSlotPanel.SetActive(false);
    }

    private void OpenOption()
    {
        _optionPanel.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
