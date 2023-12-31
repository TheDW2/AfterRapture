using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerHandler : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public static SceneManagerHandler instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadScene(int sceneindex)
    {
        StartCoroutine(LoadAsynchronously(sceneindex));
    }

    IEnumerator LoadAsynchronously (int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        loadingScreen.SetActive(true);


        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
