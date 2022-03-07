using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text currentScoreText;
    public Text highScoreText;
    public int currentScore = 0;
    public int highScore = 0;
    
    void Start()
    {
        
        // Gets and sets hi-score on highscore var
        highScore = PlayerPrefs.GetInt("hi-score");
        //Enemy.enemyDead = 
        currentScoreText.text = currentScore.ToString("0000");
        highScoreText.text = highScore.ToString("0000");


    }

    public void addScore(int enemyValue)
    {
         
        currentScore += enemyValue;
        currentScoreText.text = currentScore.ToString("0000");
    }

    public void changeHighscore(int newHighScore)
    {
        highScore = newHighScore;
        PlayerPrefs.SetInt("hi-score", highScore);
        highScoreText.text = highScore.ToString("0000");
    }

    // public void updateScore()
    // {
    //     currentScoreText.text = currentScore.ToString("0000");
    //     highScoreText.text = highScore.ToString("0000");
    // }
    // Update is called once per frame
    void Update()
    {
        if (currentScore > highScore)
        {
            changeHighscore(currentScore);
        }
    }
}


