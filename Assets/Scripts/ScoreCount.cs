using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private Text _textScore;
   
    public static int scoreCount = 0;
    public static bool checkBoss;

    private void Update()
    {
        _textScore.text = " " + scoreCount;

        if(scoreCount == 210)
        {
            checkBoss = true;
        }
    }

    public void ScoreSmallAsteroid()
    {
        scoreCount += 10; 
    }

    public void ScoreMiddleAsteroid()
    {
        scoreCount += 20;
    }

    public void ScoreBigAsteroid()
    {
        scoreCount += 40;
    }
}
