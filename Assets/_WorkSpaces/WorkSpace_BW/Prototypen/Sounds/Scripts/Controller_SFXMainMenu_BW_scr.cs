using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;


public class Controller_SFXMainMenu_BW_scr : MonoBehaviour
{
    [SerializeField] private AudioClip[] _buttonSound;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.AddEventListener("OnButtonPress", OnButtonPress);
    }

    private void OnDisable()
    {
        EventManager.RemoveEventListener("OnButtonPress", OnButtonPress);
    }

    private void OnButtonPress(object sender, object eventArgs)
    {
        _audio.clip = _buttonSound[Random.Range(0, _buttonSound.Length)];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //hier dann if, wenn der Knopf im Menu gedrückt wird

    }
}
