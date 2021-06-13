using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
public class Controller_Intro_BR_scr : MonoBehaviour
{
    public void OnGotoMainMenuClicked()
    {
        Nvp.Events.EventManager.Invoke(GameEvents.OnSwitchIntroToMainMenu, this, null);
    }

    void Start()
    {
        EventManager.Invoke("OnIntroShown", this, null);
    }
}
