using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class Controller_BackgroundMusic_BW_scr : MonoBehaviour
{
    [SerializeField] private AudioClip[] _introMusicClips;
    [SerializeField] private AudioClip[] _mainMenuClips;
    [SerializeField] private AudioClip[] _creditsMusicClips;
    [SerializeField] private AudioClip[] _gameMusicClips;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.AddEventListener("OnIntroShown", OnIntroShown);
        EventManager.AddEventListener("OnMainMenuShown", OnMainMenuShown);
        EventManager.AddEventListener("OnCreditsShown", OnCreditsShown);
        EventManager.AddEventListener("OnGameShown", OnGameShown);

    }

    

    private void OnDisable()
    {
        EventManager.RemoveEventListener("OnIntroShown", OnIntroShown);
        EventManager.RemoveEventListener("OnMainMenuShown", OnMainMenuShown);
        EventManager.RemoveEventListener("OnCreditsShown", OnCreditsShown);
        EventManager.RemoveEventListener("OnGameShown", OnGameShown);
    }

    private void OnIntroShown(object sender, object eventArgs)
    {
        _audio.clip = _introMusicClips[Random.Range(0, _introMusicClips.Length)];
        _audio.Play();
    }

    private void OnMainMenuShown(object sender, object eventArgs)
    {
        _audio.clip = _mainMenuClips[Random.Range(0, _mainMenuClips.Length)];
        _audio.Play();
    }

    private void OnCreditsShown(object sender, object eventArgs)
    {
        _audio.clip = _creditsMusicClips[Random.Range(0, _creditsMusicClips.Length)];
        _audio.Play();
    }

    private void OnGameShown(object sender, object eventArgs)
    {
        _audio.clip = _gameMusicClips[Random.Range(0, _gameMusicClips.Length)];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Invoke("OnIntroShown", this, null);
        }
    }
}
