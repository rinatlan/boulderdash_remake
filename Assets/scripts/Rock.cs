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
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("rock")))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    
}
