using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_SoundRopeBroken_DV_scr : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.AddEventListener("OnRopeBroken", OnRopeBroken);
    }

    private void OnDisable()
    {
        EventManager.RemoveEventListener("OnRopeBroken", OnRopeBroken);
    }

    private void OnRopeBroken(object sender, object eventargs)
    {
        this.GetComponent<AudioSource>().Play();
    }
}
