
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;

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
    
    public Bird bird;
    public PipesManager pipesManager;
    public Image startImage;
    public Image gameOverImage;
    



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


    }
    public void GameOver()
    {
        status = GameStatus.GameOver;
        gameOverImage.enabled = true;
       
    }
    void GameOverUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }
    void Restart()
    {
        
        status = GameStatus.Start;
        bird.Restart();
        pipesManager.Restart();
        startImage.enabled = true;
        gameOverImage.enabled = false;

    }
}
