using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Nvp.Events;
using UnityEngine;

public class Controller_Game_BR_scr : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.AddEventListener("OnEndSuccess", OnEndSuccess);
        EventManager.AddEventListener("OnEndFail", OnEndFail);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnEndSuccess", OnEndSuccess);
        EventManager.RemoveEventListener("OnEndFail", OnEndFail);
    }

    private void OnEndFail(object sender, object eventargs)
    {
        
    }

    private void OnEndSuccess(object sender, object eventargs)
    {
        
    }

    public void Update()
    {
        
    }

}
