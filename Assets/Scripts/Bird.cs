using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    private Vector3 StartPosition;


    void Start()
    {
        rig.bodyType = RigidbodyType2D.Static;
        StartPosition = transform.position;
    }

    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                StartUpdate();
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                break;
        }

    }
    public void StartGame()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Jump();
    }

    void StartUpdate()
    {
       
    }

    void PlayUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void GameOverUpdate()
    {

    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }

   public void Restart()
    {
        transform.position = StartPosition;
        rig.bodyType = RigidbodyType2D.Static;
    }
}
