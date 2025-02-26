using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public enum GameState
{
    Playing,
    Ending
}
public class GameManager : Singleton<GameManager>
{
    [Header("Gameplay Settings")]
    private int _score = 0;

    public int Score
    {
        set
        {
            _score = value;
            /*if (_score >= scoreTarget)
            {
                //todo win
                CurrentGameState = GameState.Ending;
            }else if (_score < 0)
            {
                //todo lose
                CurrentGameState = GameState.Ending;
            }*/
        }
        get => _score;
    }
    public int scoreTarget = 500;

    [Header("Combo Settings")]
    // Cần 5 đấm liên tục để kích hoạt combo
    public int comboRequirement = 5;  
    public bool comboActive = false;
    public int consecutiveHits = 0;
    
    [Header("Spawn Settings")]
    [SerializeField]
    private Transform spawnPointLeft;
    [SerializeField]
    private Transform spawnPointRight;
    public float levelTime = 30f;
    public float speedBallBase = 30f;
    [SerializeField] 
    private float intervalSpawn;

    private float _currentBallSpeed = 30f;
    
    
    public Action OnGameStarting;
    public Action OnGameEnding;
    private int _currentLevel=1;


    private List<SpawnerType> BallSpawnerTypeList = new List<SpawnerType>()
    {
        SpawnerType.RedBall,
        SpawnerType.YellowBall,
        SpawnerType.WhiteBall,
        SpawnerType.GreyBall,
        SpawnerType.OrangeBall
    };
    public int CurrentLevel
    {
        get => _currentLevel;
        set => _currentLevel = Mathf.Clamp(value, 1, _currentLevel);
    }
    private GameState _currentGameState;
    public GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            _currentGameState = value;
            switch (_currentGameState)
            {
                case GameState.Playing:
                    OnGameStarting?.Invoke();
                    /*BGSoundManager.Instance.PlayBackgroundSound();*/
                    Time.timeScale = 1;
                    break;
                case GameState.Ending:
                    OnGameEnding?.Invoke();
                    Time.timeScale = 0;
                    /*Sequence(Delay(1.0).OnComplete(() =>
                    {
                        BGSoundManager.Instance.StopBackgroundSound();
                    }));*/
                    break;
            }
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad();
    }

    private void Start()
    {
        CurrentGameState = GameState.Playing;
        ResetData();
        intervalSpawn = levelTime / _currentBallSpeed;
        StartCoroutine(SpawnBall());
    }

    private void ResetData()
    {
        levelTime = 30f;
        Score = 0;
        comboActive = false;
        consecutiveHits = 0;
        if (CurrentLevel == 1)
        {
            _currentBallSpeed = speedBallBase;
        }
        else
        {
            _currentBallSpeed *= .1f;
        }
    }

    #region Logic and Events

    public void AddScore(int amount)
    {
        // Nếu comboActive và amount > 0 (đấm đúng) => nhân đôi
        if (comboActive && amount > 0)
        {
            amount *= 2;
        }

        Score += amount;

        // Xử lý combo
        if (amount > 0)
        {
            consecutiveHits++;
            if (consecutiveHits >= comboRequirement)
            {
                comboActive = true;
            }
        }
        else
        {
            // Đấm sai => reset combo
            consecutiveHits = 0;
            comboActive = false;
        }

        //UpdateUI();
    }
   
    void EndLevel()
    {
        if (Score >= scoreTarget)
        {
            Debug.Log("Level Passed!");
        }
        else
        {
            Debug.Log("Level Failed!");
        }
        /*ResetLevel();*/
    }
    void ResetLevel()
    {
        //timer = levelTime;
        Score = 0;
        comboActive = false;
        consecutiveHits = 0;
        //UpdateUI();
    }

    #endregion

    #region Spawn Level

    IEnumerator SpawnBall()
    {
        while (CurrentGameState== GameState.Playing)
        {
            var randomTypeLeft = GetRandomBallType();
            Transform ballLeft = ObjectPutter.Instance.PutObject(randomTypeLeft);
            if (ballLeft)
            {
                ballLeft.position = spawnPointLeft.position;
                ballLeft.rotation = spawnPointLeft.rotation;
                if (ballLeft.TryGetComponent(out Ball ballLeftComponent))
                {
                    ballLeftComponent.ActiveForce(_currentBallSpeed);
                }
            }

            var randomTypeRight = GetRandomBallType();
            Transform ballRight = ObjectPutter.Instance.PutObject(randomTypeRight);
            if (ballRight)
            {
                ballRight.position = spawnPointRight.position;
                ballRight.rotation = spawnPointRight.rotation;
                if (ballRight.TryGetComponent(out Ball ballRightComponent))
                {
                    ballRightComponent.ActiveForce(_currentBallSpeed);
                }
            }

            yield return new WaitForSeconds(intervalSpawn);
        }
    }

    SpawnerType GetRandomBallType()
    {
        var randomIndex = Random.Range(0, BallSpawnerTypeList.Count);
        return BallSpawnerTypeList[randomIndex];
    }
    #endregion
    
}
