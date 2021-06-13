using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Nvp.Events;
using UnityEngine;

public class Controller_Game_BR_scr : MonoBehaviour
{
    [SerializeField] private int _maxButterflies;
    [SerializeField] private int _butterfliesCollected;
    [SerializeField] private float _gameTime;

    void OnEnable()
    {
        EventManager.AddEventListener("OnCollecting", OnCollecting);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnCollecting", OnCollecting);
    }

    private void OnCollecting(object sender, object eventargs)
    {
        _butterfliesCollected += 1;
    }

    void Update()
    {
        
    }
}
