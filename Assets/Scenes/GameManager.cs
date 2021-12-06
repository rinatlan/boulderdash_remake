using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _shared;
    
    private int _points = 0;
    private static int _lives = 3;
    public GameObject[] livesList;
    private int _timeRemains = 150;
    private int _numDiamondsEaten = 0;

    private void Awake()
    {
        _shared = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static int GetPoints()
    {
        return _shared._points;
    }
    public static void AddPoints()
    {
        _shared._points += 10;
    }

    
    
    public static void MinusLive()
    {
        _lives -= 1;
        if (_lives > 0)
        {
            SceneManager.LoadScene("Game");
            //_shared.livesList[0].gameObject.SetActive(false);
        }
        else
        {
            print("GAME OVER!");
        }

    }
    
    public static void AddDiamond()
    {
        _shared._numDiamondsEaten += 1;
    }
   
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
