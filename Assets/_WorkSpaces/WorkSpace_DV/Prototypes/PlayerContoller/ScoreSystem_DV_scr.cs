using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
using UnityEngine.UI;

public class ScoreSystem_DV_scr : MonoBehaviour
{
    public static int score, highscore; 
    public int scoreItem, scoreButterfly, scoreWasp, scoreDamage, scoreNet;
    public Text scoreText, highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        
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
        scoreText.text = score.ToString();
        highscoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
        }
    }

    public void ScoreItemCollect(object sender, object eventArgs)
    {
        score += scoreItem;
    }

    public void ScoreButterflyCollect(object sender, object eventArgs)
    {
        score += scoreButterfly;
    }

    public void ScoreWaspCollect(object sender, object eventArgs)
    {
        score -= scoreWasp;
    }

    public void ScoreTakeDamage(object sender, object eventArgs)
    {
        score -= scoreDamage;
    }

    public void ScoreNetDestroy(object sender, object eventArgs)
    {
        score -= scoreNet;
    }
}