using System.Collections;
using Nvp.Events;
using UnityEngine;

public class Controller_Laver_DV_scr : MonoBehaviour
{
    [SerializeField] private string _eventToInvoke;
    private bool laverON = false;


    public void InvokeEvent()
    {
        if (!laverON)
        {
            Debug.Log("hit laver");
            laverON = true;
            // Debug.Log($"{_eventToInvoke}");
            EventManager.Invoke(_eventToInvoke, this, null);
            StartCoroutine(ResetLaver());
        }
    }

    private IEnumerator ResetLaver()
    {
        yield return new WaitForSeconds(30f);
        laverON = false;
    }
}