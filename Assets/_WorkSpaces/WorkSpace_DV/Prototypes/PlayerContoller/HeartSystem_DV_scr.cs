using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;

public class HeartSystem_DV_scr : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
    }

    private void OnEnable()
    {
        EventManager.AddEventListener("TakeDamage", TakeDamage);
    }

    private void OnDisable()
    {
        EventManager.RemoveEventListener("TakeDamage", TakeDamage);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            EventManager.Invoke("OnEndFail", this, null);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            EventManager.Invoke("TakeDamage", this, null);
            EventManager.Invoke("ScoreTakeDamage", this, null);
        }
    }

    public void TakeDamage(object sender, object eventArgs)
    {
        life -= 1;
        Destroy(hearts[life].gameObject);
        if (life < 1)
        {
            dead = true;
        }
    }
}
