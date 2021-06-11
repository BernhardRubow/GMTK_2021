using System;
using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Scene_BR_scr : MonoBehaviour
{
    [SerializeField] string _nameOfStartScene;
    [SerializeField] private string _currentScene;

    [SerializeField] private Camera _cam;  


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(LoadScene(_nameOfStartScene));
    }

    void OnEnable()
    {
        EventManager.AddEventListener(GameEvents.OnSwitchIntroToMainMenu, OnSwitchIntroToMainMenu);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener(GameEvents.OnSwitchIntroToMainMenu, OnSwitchIntroToMainMenu);
    }

    private void OnSwitchIntroToMainMenu(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_MainMenu"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        var lastScene = _currentScene;
        _currentScene = sceneName;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.completed += (aop) => { 

            _cam.gameObject.SetActive(false);

            if (!String.IsNullOrEmpty(lastScene))
            {
                SceneManager.UnloadSceneAsync(lastScene);
            }
        };

        while(!asyncOperation.isDone){
            yield return null;
        }  
    }

}
