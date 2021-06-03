using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text ScoreText;
    public Text HighScoreText;
    public static int score = 0;
    public int Highscore;
    public static ScoreScript instance;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            Highscore = PlayerPrefs.GetInt("SaveScore");
            HighScoreText.text = "High Score:" + Highscore.ToString();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Score()
    {
        score += 30;
        ScoreText.text = "Score:" + score.ToString();
        HighScore();

    }

    public void HighScore()
    {
        if (score > Highscore)
        {
            Highscore = score;
            HighScoreText.text = "High Score:" + Highscore.ToString();

        }

        PlayerPrefs.SetInt("SaveScore", Highscore);

    }
}
