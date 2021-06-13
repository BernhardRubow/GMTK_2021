using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class Controller_BackgroundMusic_BW_scr : MonoBehaviour
{
    [SerializeField] private AudioClip[] _introMusicClips;
    [SerializeField] private AudioClip[] _mainMenuClips;
    [SerializeField] private AudioClip[] _endScreenClips;
    [SerializeField] private AudioClip[] _creditsMusicClips;
    [SerializeField] private AudioClip[] _gameMusicClips;
    [SerializeField] private AudioClip[] _biomGrandpa;
    [SerializeField] private AudioClip[] _biomWoods;
    [SerializeField] private AudioClip[] _biomBeach;
    [SerializeField] private AudioClip[] _biomFlower;
    [SerializeField] private AudioClip[] _biomTundra;
    [SerializeField] private AudioClip[] _attackMusic;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Event start and maker
        EventManager.AddEventListener("OnIntroShown", OnIntroShown);
        EventManager.AddEventListener("OnMainMenuShown", OnMainMenuShown);
        EventManager.AddEventListener("OnEndScreenShown", OnEndScreenShown);
        EventManager.AddEventListener("OnCreditsShown", OnCreditsShown);
        EventManager.AddEventListener("OnGameShown", OnGameShown);
        EventManager.AddEventListener("OnGrandpa", OnGrandpa);
        EventManager.AddEventListener("OnWoods", OnWoods);
        EventManager.AddEventListener("OnBeach", OnBeach);
        EventManager.AddEventListener("OnFlowers", OnFlowers);
        EventManager.AddEventListener("OnTundra", OnTundra);
        EventManager.AddEventListener("OnBeeAttack", OnBeeAttack);

    }

    private void OnDisable()
    {
        // Disable Events
        EventManager.RemoveEventListener("OnIntroShown", OnIntroShown);
        EventManager.RemoveEventListener("OnMainMenuShown", OnMainMenuShown);
        EventManager.RemoveEventListener("OnEndScreenShown", OnEndScreenShown);
        EventManager.RemoveEventListener("OnCreditsShown", OnCreditsShown);
        EventManager.RemoveEventListener("OnGameShown", OnGameShown);
        EventManager.RemoveEventListener("OnGrandpa", OnGrandpa);
        EventManager.RemoveEventListener("OnWoods", OnWoods);
        EventManager.RemoveEventListener("OnBeach", OnBeach);
        EventManager.RemoveEventListener("OnFlowers", OnFlowers);
        EventManager.RemoveEventListener("OnTundra", OnTundra);
        EventManager.RemoveEventListener("OnBeeAttack", OnBeeAttack);
    }

    private void OnIntroShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnIntroShown
        _audio.clip = _introMusicClips[Random.Range(0, _introMusicClips.Length)];
        _audio.Play();
    }

    private void OnMainMenuShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnMainMenuShown
        _audio.clip = _mainMenuClips[Random.Range(0, _mainMenuClips.Length)];
        _audio.Play();
    }

    private void OnEndScreenShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnMainMenuShown
        _audio.clip = _endScreenClips[Random.Range(0, _endScreenClips.Length)];
        _audio.Play();
    }

    private void OnCreditsShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnCreditsShown
        _audio.clip = _creditsMusicClips[Random.Range(0, _creditsMusicClips.Length)];
        _audio.Play();
    }

    private void OnGameShown(object sender, object eventArgs)
    {
        // Play Sounds for Event OnGameShown
        _audio.clip = _gameMusicClips[Random.Range(0, _gameMusicClips.Length)];
        _audio.Play();
    }

    private void OnGrandpa(object sender, object eventArgs)
    {
        // Play Sounds for Event OnGrandpa
        _audio.clip = _biomGrandpa[Random.Range(0, _biomGrandpa.Length)];
        _audio.Play();
    }

    private void OnWoods(object sender, object eventArgs)
    {
        // Play Sounds for Event OnWoods
        _audio.clip = _biomWoods[Random.Range(0, _biomWoods.Length)];
        _audio.Play();
    }

    private void OnBeach(object sender, object eventArgs)
    {
        // Play Sounds for Event OnBeach
        _audio.clip = _biomBeach[Random.Range(0, _biomBeach.Length)];
        _audio.Play();
    }

    private void OnFlowers(object sender, object eventArgs)
    {
        // Play Sounds for Event OnFlowers
        _audio.clip = _biomFlower[Random.Range(0, _biomFlower.Length)];
        _audio.Play();
    }

    private void OnTundra(object sender, object eventArgs)
    {
        // Play Sounds for Event OnTundra
        _audio.clip = _biomTundra[Random.Range(0, _biomTundra.Length)];
        _audio.Play();
    }

    private void OnBeeAttack(object sender, object eventArgs)
    {
        // Play Sounds for Event OnBeeAttack
        _audio.clip = _attackMusic[Random.Range(0, _attackMusic.Length)];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //// only for testing
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    EventManager.Invoke("OnIntroShown", this, null);
        //}
    }
}
