using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodsteps_DV_scr : MonoBehaviour
{
    private float speedX;
    private float speedY;
    public string xAxis;
    public string yAxis;
    private AudioSource foodstep;


    // Start is called before the first frame update
    void Start()
    {
        foodstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis(xAxis);
        speedX = Input.GetAxis(yAxis);

        if (speedX == 0 && speedY == 0)
        {
            foodstep.Stop();
        }
        else if (!foodstep.isPlaying)
        {
            foodstep.Play();
        }
    }
}
