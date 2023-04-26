using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public Text highscoreText;
    public int highscore;
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);

        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }

    public void IncreaseScore(int points)
    {
        score += points;

        scoreText.text = score.ToString();


        if(score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }
    }

    public void OnBombHit()
    {

        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        Debug.Log("HitBomb");
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        Time.timeScale = 1;

        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "Score 0";

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
    }


}
