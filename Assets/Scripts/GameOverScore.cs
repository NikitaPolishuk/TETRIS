using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text ScoreText;

    
    void Start()
    {
        ScoreText.text = "Score:" + ScoreScript.score.ToString();
    }

    
    void Update()
    {
        
    }
}
