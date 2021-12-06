using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    private Vector2 _movement;
    private float _moveSpeed = 5f;
    private Vector2 _direction = new Vector2(1, 1);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // player moves according to pressed arrow
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _movement.x = -2.5f;
            _movement.y = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _movement.x = 2.5f;
            _movement.y = 0;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _movement.x = 0;
            _movement.y = 2.5f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _movement.x = 0;
            _movement.y = -2.5f;
        }
        else
        {
            _movement.x = 0;
            _movement.y = 0;
        }
    }

    private void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + _movement * _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        // player collected diamond
        // need to increase points by 10
        if (other.gameObject.CompareTag("diamond"))
        {
            other.gameObject.SetActive(false);
            GameManager.AddPoints();
            GameManager.AddDiamond();
        }
        
        // player moves in the sand
        else if (other.gameObject.CompareTag("sand"))
        {
            other.gameObject.SetActive(false);
        }
        
    }

    //  if rock fell on the player: 
    // need to deactivated the player and 5 object near it
    // need to restart the scene (game) with 2 lives
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 size = new Vector2(2, 2);
        Vector2 lastPosPlayer = rigidBody2D.position;
        print(other.name);
        gameObject.SetActive(false);
        var hits = Physics2D.OverlapBoxAll(lastPosPlayer, size, 90);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("wall") == false | hit.gameObject.CompareTag("wallFloor") == false)
            {
                hit.gameObject.SetActive(false);
            }
        }

        
        GameManager.MinusLive();
    }

    
}
