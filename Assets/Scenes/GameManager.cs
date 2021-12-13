using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _shared;
    public static bool playerMove;
    private int _points = 0;
    private static int _lives = 3;
    public GameObject[] livesList;
    private int _timeRemains = 150;
    private int _numDiamondsEaten = 0;

    private GameObject playerObj;

    public GameObject wallPrefab;
    public GameObject sandPrefab;
    public GameObject playerPrefab;
    public GameObject diamondPrefab;
    public GameObject rockPrefab;
    
    
    private int wall = 1;
    private int sand = 2;
    private int player = 3;
    private int diamond = 4;
    private int rock = 5;
    private int nothing = 0;

    private int[][] board =
    {
        new int[7]
        {
            1, 1, 1, 1, 1, 1, 1
        },
        new int[7]
        {
            1, 2, 2, 5, 2, 4, 1
        },
        new int[7]
        {
            1, 2, 3, 2, 5, 2, 1
        },
        new int[7]
        {
            1, 5, 2, 0, 4, 2, 1
        },
        new int[7]
        {
            1, 2, 4, 2, 2, 0, 1
        },
        new int[7]
        {
            1, 1, 1, 1, 1, 1, 1
        }
    };
    
    private void Awake()
    {
        _shared = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        InitBoard();
    }

    private void InitBoard()
    {
        Vector2 originalPos = new Vector2(-2.5f, 1.5f);
        int counterX = 0;
        int counterY = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Vector2 newPos = new Vector2(counterX, counterY);
                switch (board[i][j])
                {
                    case 1: 
                        Instantiate(wallPrefab, originalPos + newPos, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(sandPrefab, originalPos + newPos, Quaternion.identity);
                        break;
                    case 3:
                        playerObj = Instantiate(playerPrefab, originalPos + newPos, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(diamondPrefab, originalPos + newPos, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(rockPrefab, originalPos + newPos, Quaternion.identity);
                        break;
                }
                counterX += 1;
            }
            counterX = 0;
            counterY -= 1;
        }
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
