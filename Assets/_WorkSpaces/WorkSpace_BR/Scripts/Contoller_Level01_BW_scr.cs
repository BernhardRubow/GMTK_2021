using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class Contoller_Level01_BW_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Invoke("OnGrandpa", this, null);
    }
}
