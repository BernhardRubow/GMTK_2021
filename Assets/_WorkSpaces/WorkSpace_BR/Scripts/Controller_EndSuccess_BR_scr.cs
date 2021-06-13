using Nvp.Events;
using UnityEngine;

public class Controller_EndSuccess_BR_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Invoke("OnEndSuccessLoaded", this, null);

    }
    
}