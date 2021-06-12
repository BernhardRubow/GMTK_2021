using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_SFX_DV_scr : MonoBehaviour
{
    [SerializeField] private AudioClip[] _playerSFX;
    [SerializeField] private AudioClip[] _butterflySFX;
    [SerializeField] private AudioClip[] _waspSFX;
    [SerializeField] private AudioClip[] _leverSwitch;
    [SerializeField] private AudioClip[] _itemCollect;
    [SerializeField] private AudioClip[] _netDestroy;
    [SerializeField] private AudioClip[] _obstacleDestroy;
    [SerializeField] private AudioClip[] _playerTakeDamage;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
