using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class Controller_SFXInGame_BW_scr : MonoBehaviour
{
    [SerializeField] private AudioClip[] _damageSound;
    [SerializeField] private AudioClip[] _beeSound;
    [SerializeField] private AudioClip[] _butterflySound;
    [SerializeField] private AudioClip[] _collectorSound;
    [SerializeField] private AudioClip[] _leaverSound;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Event start and maker
        EventManager.AddEventListener("OnDamage", OnDamage);
        EventManager.AddEventListener("OnBeeShown", OnBeeShown);
        EventManager.AddEventListener("OnButterflyShown", OnButterflyShown);
        EventManager.AddEventListener("OnCollecting", OnCollecting);
        EventManager.AddEventListener("OnLeaver", OnLeaver);
    }

    private void OnDisable()
    {
        // Disable Events
        EventManager.RemoveEventListener("OnDamage", OnDamage);
        EventManager.RemoveEventListener("OnBeeShown", OnBeeShown);
        EventManager.RemoveEventListener("OnButterflyShown", OnButterflyShown);
        EventManager.RemoveEventListener("OnCollecting", OnCollecting);
        EventManager.RemoveEventListener("OnLeaver", OnLeaver);
    }

    private void OnDamage(object sender, object eventArgs)
    {
        // Play Sounds for Event OnButtonPress
        _audio.clip = _damageSound[Random.Range(0, _damageSound.Length)];
        _audio.Play();
    }

    private void OnBeeShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnButtonPress
        _audio.clip = _beeSound[Random.Range(0, _beeSound.Length)];
        _audio.Play();
    }

    private void OnButterflyShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnButtonPress
        _audio.clip = _butterflySound[Random.Range(0, _butterflySound.Length)];
        _audio.Play();
    }

    private void OnCollecting(object sender, object eventArgs)
    {
        // Play Sounds for Event OnButtonPress
        _audio.clip = _collectorSound[Random.Range(0, _collectorSound.Length)];
        _audio.Play();
    }

    private void OnLeaver(object sender, object eventArgs)
    {
        // Play Sounds for Event OnButtonPress
        _audio.clip = _leaverSound[Random.Range(0, _leaverSound.Length)];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}