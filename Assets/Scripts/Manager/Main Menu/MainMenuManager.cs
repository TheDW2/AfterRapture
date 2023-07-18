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

    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private Button _closeAboutButton;

    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private GameObject _saveSlotPanel;

    [SerializeField] private GameObject _aboutPanel;

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
        _aboutButton.onClick.AddListener(OpenAboutPanel);
        _closeAboutButton.onClick.AddListener(CloseAboutPanel);
        _closeButton.onClick.AddListener(Close);
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

    private void OpenAboutPanel() {
        _aboutPanel.SetActive(true);
    }

    private void CloseAboutPanel() {
        _aboutPanel.SetActive(false);
    }

    private void Close() {
        _optionPanel.SetActive(false);
    }
}
