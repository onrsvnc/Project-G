using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ModifyScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
        scoreKeeper.currentScore = score;
    }
}
