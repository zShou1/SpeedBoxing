using System;
using DG.Tweening;
using UnityEngine;

public enum GameState
{
    Playing,
    Ending
}
public class GameManager : Singleton<GameManager>
{
    [Header("Gameplay Settings")]
    public int score = 0;
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

    private float _currentBallSpeed = 30f;
    
    
    public Action OnGameStarting;
    public Action OnGameEnding;
    private int _currentLevel=1;
    public int CurrentLevel
    {
        get
        {
            if (PlayerPrefs.HasKey(Constants.CurrentLevelKey))
            {
                _currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevelKey, 1);
            }
            return _currentLevel;
        }
        set
        {
            _currentLevel = Mathf.Clamp(value, 1, 3);
            PlayerPrefs.SetInt(Constants.CurrentLevelKey, _currentLevel);
            PlayerPrefs.Save();
        }
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
    }
    

    #region Logic and Events

    public void AddScore(int amount)
    {
        // Nếu comboActive và amount > 0 (đấm đúng) => nhân đôi
        if (comboActive && amount > 0)
        {
            amount *= 2;
        }

        score += amount;

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
        // Kiểm tra xem có đủ điểm không
        if (score >= scoreTarget)
        {
            Debug.Log("Level Passed!");
        }
        else
        {
            Debug.Log("Level Failed!");
        }
        // Reset level hoặc chuyển sang level tiếp theo...
        ResetLevel();
    }
    void ResetLevel()
    {
        //timer = levelTime;
        score = 0;
        comboActive = false;
        consecutiveHits = 0;
        //UpdateUI();
    }

    #endregion

    #region Spawn Level

    private void SpawnBall()
    {
        // Tạo bóng
        //ObjectPutter.Instance.PutObject(SpawnerType.Ball);
    }
    #endregion
    
}
