
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using TMPro;

public enum GameStatus
{
    Start,
    Play,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStatus status = GameStatus.Start;
    public float speed;
    public Bird bird;
    public PipesManager pipesManager;
    public Image startImage;
    public Image gameOverImage;
    public TMP_Text scoreText;
    public TMP_Text BestScoreText;
    int score = 0;
    private float gameOverTime = 0f;
    private string bestScoreKey = "bestScore";
    private int bestScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        startImage.enabled = true;
        gameOverImage.enabled = false;
        BestScoreText.enabled = true;
        scoreText.enabled = true;
        bestScore = PlayerPrefs.GetInt(bestScoreKey);
        BestScoreTextUpdate();
    }
    private void Update()
    {
        switch (status)
        {
            case GameStatus.Start:
                StartUpdate();
                break; 
            case GameStatus.Play:
                break;
            case GameStatus.GameOver:
                GameOverUpdate();
                break;
        }
    }
    private void StartUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        status = GameStatus.Play;
        bird.StartGame();
        startImage.enabled = false;
        scoreText.enabled = true;
        BestScoreText.enabled = false;
    }
    public void GameOver()
    {
        status = GameStatus.GameOver;
        gameOverImage.enabled = true;
        scoreText.enabled = true;
        BestScoreText.enabled = true;
        if (score > bestScore)
            bestScore = score;
            PlayerPrefs.SetInt(bestScoreKey, bestScore);
            BestScoreTextUpdate();
    }
    void GameOverUpdate()
    {
        gameOverTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (gameOverTime > 1)
            {
                Restart();
 
            }
      
        }
    }
    void Restart()
    {
        status = GameStatus.Start;
        bird.Restart();
        pipesManager.Restart();
        startImage.enabled = true;
        gameOverImage.enabled = false;
        score = 0;
        gameOverTime = 0;
        scoreText.enabled = false;
        BestScoreText.enabled = true;
        ScoreTextUpdate(); 
    }
    public void addScore()
    {
        score++;
        ScoreTextUpdate();
    }
    private void ScoreTextUpdate()

    {
        scoreText.text = "Score: "+score.ToString();
    }
    private void BestScoreTextUpdate()
    {
        BestScoreText.text = "Best:" + bestScore.ToString();
    }
}
