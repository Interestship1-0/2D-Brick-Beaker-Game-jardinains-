using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameStauts : MonoBehaviour
{
    public int pointsPerBreak = 0;
    private int currentScore = 0;
    
    public Text scoreText;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    public void UpdateScore(){
        currentScore = currentScore + pointsPerBreak;
        scoreText.text = currentScore.ToString();
    }
}
