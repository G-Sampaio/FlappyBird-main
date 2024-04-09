using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    private Vector3 StartPosition;
    public Animator animator;


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
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 6:
                GameOver();
                break;
            case 7:
                GameManager.instance.addScore();
                break;
            default:
                break;

        }
    }
    private void GameOver()
    {
        GameManager.instance.GameOver();
        animator.SetBool("IsAlive", false);

    }

    public void Restart()
    {
        transform.position = StartPosition;
        transform.rotation = Quaternion.identity;
        rig.bodyType = RigidbodyType2D.Static;
        animator.SetBool("IsAlive", true);
    }
    

}
