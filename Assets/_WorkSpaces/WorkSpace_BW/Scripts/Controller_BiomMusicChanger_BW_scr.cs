using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class Controller_BiomMusicChanger_BW_scr : MonoBehaviour
{
    [SerializeField] private string _biomEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EventManager.Invoke(_biomEvent, this, null);
        Debug.Log("OnTriggerEnter");
    }
    
    private void OnTriggerExit(Collider other)
    {
        EventManager.Invoke("OnGrandpa", this, null);
        Debug.Log("OnTriggerExit");
    }
}
