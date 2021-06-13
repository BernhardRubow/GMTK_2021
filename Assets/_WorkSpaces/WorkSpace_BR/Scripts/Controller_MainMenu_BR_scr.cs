using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;


public class Controller_MainMenu_BR_scr : MonoBehaviour
{
    public void OnGotoCredisClicked()
    {
        EventManager.Invoke(GameEvents.OnSwitchMainMenuToCredits, this, null);
    }

    public void OnGotoIntroClicked()
    {
        EventManager.Invoke(GameEvents.OnSwitchMainMenuToIntro, this, null);
    }

    public void OnGotoGamelicked()
    {
        EventManager.Invoke(GameEvents.OnSwitchMainMenuToGame, this, null);
    }
    private void Start()
    {
        EventManager.Invoke("OnMainMenuShown", this, null);
    }
}
