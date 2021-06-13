using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_Credits_BR_scr : MonoBehaviour
{
    public void OnGotoMainMenuClicked()
    {
        EventManager.Invoke(GameEvents.OnSwitchCreditsToMainMenu, this, null);
    }
    private void Start()
    {
        EventManager.Invoke("OnCreditsShown", this, null);
    }
}
