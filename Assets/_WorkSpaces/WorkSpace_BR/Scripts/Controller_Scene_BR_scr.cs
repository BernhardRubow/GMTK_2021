using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Scene_BR_scr : MonoBehaviour
{
    [SerializeField] string _nameOfStartScene;

    private Camera _cam;  


    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        StartCoroutine(LoadScene(_nameOfStartScene));
    }

    IEnumerator LoadScene(string sceneName){

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.completed += (aop) => { 
            _cam.gameObject.SetActive(false);
        };

        while(!asyncOperation.isDone){
            yield return null;
        }  
    }

}
