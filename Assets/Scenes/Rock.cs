using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    private Vector2 _currPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //IEnumerable<KeyCode> keys = new[] {KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow};
        //foreach (var key in keys)
        //{
        //    if (Input.GetKey(key))
        //    {
        //        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("rock")))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        

        //GameManager._exitCount = 0;
    }

    private void FixedUpdate()
    {
        
    }

    
}
