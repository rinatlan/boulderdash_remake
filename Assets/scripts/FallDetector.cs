using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.transform.position.y < transform.position.y && other.CompareTag("Player")) || 
            (other.transform.position.y < transform.position.y && other.CompareTag("rock")))
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    
}
