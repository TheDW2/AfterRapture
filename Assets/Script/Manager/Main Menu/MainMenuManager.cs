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


    [SerializeField] private GameObject _optionPanel;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _playButton.onClick.AddListener(PlayGame);
        _optionButton.onClick.AddListener(OpenOption);
        _exitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        //check save, if there is save show pop up, if there is no save, start from the beginning
        
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
