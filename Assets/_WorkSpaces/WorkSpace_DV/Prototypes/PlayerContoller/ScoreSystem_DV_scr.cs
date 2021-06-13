using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
using UnityEngine.UI;

public class ScoreSystem_DV_scr : MonoBehaviour
{
    public static int score, highscore, butterfly, time;
    public Text scoreText, highscoreText, butterflyText, timeText;
    public int scoreItem, scoreButterfly, scoreWasp, scoreDamage, scoreNet;
    private float timeRemaining = 900;
    public bool timerIsRunning = false;
    private int butterflyMax = 42;
    
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    private void OnEnable()
    {
        EventManager.AddEventListener("ScoreItemCollect", ScoreItemCollect);
        EventManager.AddEventListener("ScoreButterflyCollect", ScoreButterflyCollect);
        EventManager.AddEventListener("ScoreWaspCollect", ScoreWaspCollect);
        EventManager.AddEventListener("ScoreTakeDamage", ScoreTakeDamage);
        EventManager.AddEventListener("ScoreNetDestroy", ScoreNetDestroy);
    }

    private void OnDisable()
    {
        EventManager.RemoveEventListener("ScoreItemCollect", ScoreItemCollect);
        EventManager.RemoveEventListener("ScoreButterflyCollect", ScoreButterflyCollect);
        EventManager.RemoveEventListener("ScoreWaspCollect", ScoreWaspCollect);
        EventManager.RemoveEventListener("ScoreTakeDamage", ScoreTakeDamage);
        EventManager.RemoveEventListener("ScoreNetDestroy", ScoreNetDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                EventManager.Invoke("OnEndFail", this, butterfly);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateScoreDisplays()
    {
        if (score > highscore)
        {
            highscore = score;
        }

        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
        butterflyText.text = butterfly.ToString() + "/" + butterflyMax.ToString();
        timeText.text = time.ToString();
    }

    public void ScoreItemCollect(object sender, object eventArgs)
    {
        score += scoreItem;
        UpdateScoreDisplays();
    }

    public void ScoreButterflyCollect(object sender, object eventArgs)
    {
        int? catchScore = eventArgs as int?;
        if (catchScore != null)
        {
           // Debug.Log(score);
           score += catchScore.Value; 
        }
        else
        { 
            score += scoreButterfly;
        }

        butterfly += 1;

        if (butterfly == butterflyMax)
        {
            timerIsRunning = false;

            EventManager.Invoke("OnEndSuccess", this, timeRemaining);
        }

        UpdateScoreDisplays();
    }

    public void ScoreWaspCollect(object sender, object eventArgs)
    {
        score -= scoreWasp;
        UpdateScoreDisplays();
    }

    public void ScoreTakeDamage(object sender, object eventArgs)
    {
        score -= scoreDamage;
        UpdateScoreDisplays();
    }

    public void ScoreNetDestroy(object sender, object eventArgs)
    {
        score -= scoreNet;

        UpdateScoreDisplays();
    }
}
