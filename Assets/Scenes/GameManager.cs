using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _shared;

    public static float xPos = -0.501f;
    public static float yPos = -0.5f;

    private int _points = 0;
    private int _numDiamondsEaten = 0;

    public int amountOfDiamond = 0;

    private GameObject playerObj;

    public GameObject wallPrefab;
    public GameObject sandPrefab;
    public GameObject playerPrefab;
    public GameObject diamondPrefab;
    public GameObject rockPrefab;
    public GameObject secondWallPrefab;
    public GameObject doorPrefab;
    
    //public GameObject canvasPrefab;
    private GameObject _canvas;
    private int _numLives = 3;
    public GameObject live1Prefab;

    private Vector3[] _lifePointsPositions = new Vector3[] {new Vector3(-226.419998f,120.389999f,0)
        , new Vector3(-210.600006f,123.910004f,0),new Vector3(-193.300003f,123.910004f,0) };
    //public GameObject live2Prefab;
    //public GameObject live3Prefab;
    // public GameObject live1;
    // public GameObject live2;
    // public GameObject live3;
    //public Canvas canvas;
    
    private int wall = 1;
    private int sand = 2;
    private int player = 3;
    private int diamond = 4;
    private int rock = 5;
    private int secondWall = 6;

    private int[][] board = 
    {
        new int[40] {
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        new int[40] {
            1,2,2,2,2,2,2,2,0,2,5,5,2,2,2,2,2,2,5,2,2,4,2,2,2,2,2,0,2,2,5,2,2,2,2,2,5,2,5,1 },
        new int[40] {
            1,2,2,3,2,2,2,2,5,2,5,5,2,2,2,2,2,2,2,2,2,5,2,2,2,5,2,2,2,2,2,2,2,2,4,2,2,2,2,1 },
        new int[40] {
            1,4,2,5,2,2,2,2,5,2,2,5,2,2,2,2,0,2,2,2,5,2,2,4,2,5,2,2,5,2,5,2,2,2,2,2,2,2,2,1},
        new int[40] {
            1,4,2,5,2,2,2,2,5,2,2,5,2,2,5,2,2,2,2,2,2,2,2,5,2,2,2,2,2,5,2,2,2,2,2,2,2,2,5,1},
        new int[40] {
            1,5,2,2,5,2,2,2,5,0,2,2,2,0,2,2,2,2,5,2,2,4,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,1},
        new int[40] {
            1,5,2,2,5,2,2,2,2,5,2,2,2,5,2,2,5,2,2,2,2,2,5,2,2,2,2,2,2,2,2,5,2,0,2,2,2,2,2,1},
        new int[40] {
            1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,5,2,5,4,2,2,0,2,1},
        new int[40] {
            1,2,5,2,2,2,5,2,2,4,2,4,2,2,5,2,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,5,5,2,2,4,2,1},
        new int[40] {
            1,2,2,2,2,2,4,2,2,2,2,2,5,0,2,2,2,2,2,2,2,2,2,2,2,4,0,2,2,2,2,2,5,2,5,2,2,5,2,1},
        new int[40] {
            1,2,2,2,5,2,2,5,2,5,2,2,2,5,2,0,0,2,2,2,2,2,2,2,2,2,5,2,2,2,4,2,2,2,2,5,2,2,2,1},
        new int[40] {
            1,5,2,2,2,5,2,2,2,2,2,2,2,5,2,5,0,2,2,2,2,2,2,2,2,2,5,5,2,2,5,2,2,2,2,2,2,2,2,1},
        new int[40] {
            1,2,2,2,2,2,5,2,5,5,2,2,2,2,2,2,5,2,2,5,2,2,2,2,2,2,2,2,5,2,2,2,2,2,5,2,0,0,2,1},
        new int[40] {
            1,2,0,2,2,2,7,2,5,5,2,2,2,2,2,2,2,2,2,5,4,2,2,5,2,2,2,2,2,2,2,2,2,5,2,2,2,2,2,1},
        new int[40] {
            1,5,4,2,2,2,2,2,2,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,1},
        new int[40] {
            1,5,4,2,2,2,2,2,2,0,2,2,5,2,2,4,4,4,2,5,2,2,5,2,2,2,2,0,2,2,2,2,2,2,2,2,5,0,0,1},
        new int[40] {
            1,2,4,2,2,2,2,5,2,2,2,5,2,2,2,2,5,2,2,5,2,4,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,1,1},
        new int[40] {
            1,2,5,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2,5,2,2,2,2,2,2,2,2,5,5,0,2,2,2,2,2,2,2,1},
        new int[40] {
            1,2,5,2,4,2,2,2,2,0,2,2,2,2,5,2,2,2,2,2,5,2,0,2,2,2,2,2,2,5,2,5,4,2,2,4,2,2,2,1},
        new int[40] {
            1,2,2,2,5,2,2,4,2,5,2,2,5,2,4,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,5,5,2,2,5,2,2,2,1},
        new int[40] {
            1,2,2,2,5,2,2,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,4,4,5,2,2,2,2,2,2,2,5,2,2,2,2,5,2,1},
        new int[40] {
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
    };
    
    private void Awake()
    {
        //_shared = this;
        
        if ( _shared == null )
        {
            _shared = this;
            //DontDestroyOnLoad(canvas);
            // DontDestroyOnLoad(live1);
            // DontDestroyOnLoad(live2);
            // DontDestroyOnLoad(live3);
            //_shared.InitBoard();
            LoadLP();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            _shared.InitBoard();
            xPos = -0.501f;
            yPos = -0.5f;
            _shared.LoadLP();
            Destroy(gameObject);
            
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        InitBoard();
    }

    private void InitBoard()
    {
        if (_shared._numLives == 0)
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else
        {
        //     //print($"in board. lives = {_shared._numLives}");
        //     if (_shared._numLives == 1)
        //     {
        //         Instantiate(live1Prefab, _canvas.transform);
        //     }
        //     else if (_shared._numLives == 2)
        //     {
        //         Instantiate(live1Prefab, _canvas.transform);
        //         Instantiate(live2Prefab, _canvas.transform);
        //     }
        //     else if (_shared._numLives == 3)
        //     {
        //         _canvas = Instantiate(canvasPrefab, canvasPrefab.GetComponent<RectTransform>().position,
        //             Quaternion.identity);
        //         Instantiate(live1Prefab, _canvas.transform);
        //         Instantiate(live2Prefab, _canvas.transform);
        //         Instantiate(live3Prefab, _canvas.transform);
        //         DontDestroyOnLoad(_canvas);
        //     }

            Instantiate(doorPrefab);
            Vector2 originalPos = new Vector2(-9f, 3.2f);
            int counterX = 0;
            int counterY = 0;
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 40; j++)
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
                        case 6:
                            Instantiate(secondWallPrefab, originalPos + newPos, Quaternion.identity);
                            break;
                    }

                    counterX += 1;
                }

                counterX = 0;
                counterY -= 1;
            }
        }
    }

    public void LoadLP()
    {
        print("aaaaa" + _numLives);
        var canvas = GameObject.FindGameObjectWithTag("canvas");
        foreach (var live in GameObject.FindGameObjectsWithTag("live"))
        {
            Destroy(live);
        }
        for (var i = 0; i < _numLives; i++)
        {
            var curLive = Instantiate(live1Prefab, canvas.transform);
            var livePos = curLive.transform.position;
            livePos.x += (_numLives + 1 - i) * 20 - 35;
            curLive.transform.position = livePos;
            //Instantiate(live1Prefab, _lifePointsPositions[i], Quaternion.identity, canvas.transform);
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
        _shared._numLives -= 1;
        SceneManager.LoadScene("Game");
        //if (_shared._numLives == 2)
        //{
        //    Destroy(_shared.lives[0].gameObject);
            //_shared.lives[0].gameObject.SetActive(false);
            //SceneManager.LoadScene("Game");
            
        //}

        //else if (_shared._numLives == 1)
        //{
            //Destroy(_shared.lives[1].gameObject);
            //SceneManager.LoadScene("Game");
        //}
        //else if (_shared._numLives == 0)
        //{
        //    ;
        //}
        

    }

    public static int GetDiamonds()
    {
        return _shared._numDiamondsEaten;
    }
    
    public static void AddDiamond()
    {
        _shared._numDiamondsEaten += 1;
    }
   
    
    // Update is called once per frame
    void Update()
    {
        //_numDiamondsEaten = amountOfDiamond;
    }
}
