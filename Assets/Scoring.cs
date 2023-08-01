using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore() // update score in UI
    {
        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(); 
    }
}
