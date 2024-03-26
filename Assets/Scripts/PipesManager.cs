using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    public GameObject pipeModel;
        
    public Transform spawnPoint;

    public float interval;

    private float currentTime = 0f;



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
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                break;
        }

    }
    void PlayUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime > interval)
        {
            CreatePipe();
            currentTime = 0f;
        }

    }
    void CreatePipe()
    {
        var pipeGameObject = Instantiate(pipeModel, spawnPoint.position, Quaternion.identity);
        var pipeTransform = pipeGameObject.GetComponent<Transform>();
        float y = Random.Range(-1.26f, 0.26f);
        pipeTransform.position = new Vector3(spawnPoint.position.x, y, 0);    
    

    }
}
