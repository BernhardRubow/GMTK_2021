using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_Game_BR_scr : MonoBehaviour
{
    [SerializeField] private int _maxButterflies;
    [SerializeField] private int _butterfliesCollected;

    void OnEnable()
    {
        //EventManager.AddEventListener("OnCollecting", OnTest);
    }

    void OnDisable()
    {

    }


}
