using System;
using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Scene_BR_scr : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] string _nameOfStartScene;
    [SerializeField] private string _currentScene;
    [SerializeField] private Camera _cam;  




    // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        StartCoroutine(LoadScene(_nameOfStartScene));
    }

    void OnEnable()
    {
        EventManager.AddEventListener(GameEvents.OnSwitchIntroToMainMenu, OnSwitchIntroToMainMenu);
        EventManager.AddEventListener(GameEvents.OnSwitchMainMenuToIntro, OnSwitchMainMenuToIntro);
        EventManager.AddEventListener(GameEvents.OnSwitchMainMenuToCredits, OnSwitchMainMenuToCredits);
        EventManager.AddEventListener(GameEvents.OnSwitchCreditsToMainMenu, OnSwitchCreditsToMainMenu);
        EventManager.AddEventListener(GameEvents.OnSwitchMainMenuToGame, OnSwitchMainMenuToGame);
        EventManager.AddEventListener("OnEndSuccess", OnSwitchGameToEndSuccess);
        EventManager.AddEventListener("OnEndFail", OnSwitchGameToEndFail);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener(GameEvents.OnSwitchIntroToMainMenu, OnSwitchIntroToMainMenu);
        EventManager.RemoveEventListener(GameEvents.OnSwitchMainMenuToIntro, OnSwitchMainMenuToIntro);
        EventManager.RemoveEventListener(GameEvents.OnSwitchMainMenuToCredits, OnSwitchMainMenuToCredits);
        EventManager.RemoveEventListener(GameEvents.OnSwitchCreditsToMainMenu, OnSwitchCreditsToMainMenu);
        EventManager.RemoveEventListener(GameEvents.OnSwitchMainMenuToGame, OnSwitchMainMenuToGame);
        EventManager.AddEventListener("OnEndSuccess", OnSwitchGameToEndSuccess);
        EventManager.AddEventListener("OnEndFail", OnSwitchGameToEndFail);
    }

    


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnSwitchMainMenuToGame(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_Level_01"));
    }

    private void OnSwitchMainMenuToIntro(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_Intro"));
    }

    private void OnSwitchIntroToMainMenu(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_MainMenu"));
    }

    private void OnSwitchMainMenuToCredits(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_Credits"));
    }

    private void OnSwitchCreditsToMainMenu(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_MainMenu"));
    }

    private void OnSwitchGameToEndFail(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_EndFail"));
    }

    private void OnSwitchGameToEndSuccess(object sender, object eventargs)
    {
        StartCoroutine(LoadScene("Scene_EndSuccess"));
    }


    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
