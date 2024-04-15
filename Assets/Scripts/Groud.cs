using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groud : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                break;
            case GameStatus.Play:
                playUpdate();
                break;
            case GameStatus.GameOver:
                break;
            default:
                break;
        }
    }

    private void playUpdate()
    {
        transform.position += Vector3.left * GameManager.instance.speed * Time.deltaTime;
        if (transform.position.x < -0.04f)
        {
            transform.position += Vector3.right * 0.24f;
        }
    }
}
