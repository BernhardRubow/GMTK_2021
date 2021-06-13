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
        EventManager.AddEventListener("OnLevel01Loaded", OnLevel01Loaded);
    }

    

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnCollecting", OnCollecting);
        EventManager.RemoveEventListener("OnLevel01Loaded", OnLevel01Loaded);
    }

    private void OnCollecting(object sender, object eventargs)
    {
        _butterfliesCollected += 1;
        if (_butterfliesCollected == _maxButterflies)
        {
            EventManager.Invoke("OnGameOver", this, null);
        }
    }

    private void OnLevel01Loaded(object sender, object eventargs)
    {
        _gameTime = 15;
        StartCoroutine(CountDownTick());
    }

    private IEnumerator CountDownTick()
    {
        while (_gameTime > 1)
        {
            yield return new WaitForSeconds(60f);
            _gameTime--;
            EventManager.Invoke("OnGameTimeChanged", this, _gameTime);
        }
        EventManager.Invoke("OnGameOver", this, null);
    }
}
