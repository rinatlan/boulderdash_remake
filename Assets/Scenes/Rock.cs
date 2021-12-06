using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerable<KeyCode> keys = new[] {KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow};
        foreach (var key in keys)
        {
            if (Input.GetKey(key))
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
    
}
