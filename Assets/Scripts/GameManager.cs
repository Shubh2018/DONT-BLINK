using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager DNE");

            return _instance;
        }
    }
    [SerializeField]
    float timer = 5.0f;
    [SerializeField]
    bool StartTimer = true;
    [SerializeField]
    bool isEnemyVisible = false;
    [SerializeField]
    GameObject[] _enemyCount;
    [SerializeField]
    bool hasWon = false;
    int noOfEnemy;
    bool isPlayerDead = false;

    public bool IsEnemyVisible
    {
        get
        {
            return isEnemyVisible;
        }

        set
        {
            isEnemyVisible = value;
        }
    }

    public bool HasWon
    {
        get
        {
            return hasWon;
        }
    }

    public int NoOfEnemy
    {
        get
        {
            return noOfEnemy;
        }

        set
        {
            noOfEnemy = value;
        }
    }

    public bool IsPlayerDead
    {
        get
        {
            return isPlayerDead;
        }

        set
        {
            isPlayerDead = value;
        }
    }

    void Awake()
    {
        _instance = this;
        noOfEnemy = 0;
    }

    void Start()
    {
        Camera.main.backgroundColor = new Color(Random.value, Random.value, Random.value);
        hasWon = false;
    }

    void Update()
    {
        if(StartTimer)
            Timer();

        if (noOfEnemy == _enemyCount.Length)
            hasWon = true;
    }

    void Timer()
    {   
        timer -= Time.deltaTime;
         
        if(timer < 0 && !isEnemyVisible)
        {
            Camera.main.backgroundColor = Color.black;
            timer = 2.5f;
            StartTimer = !StartTimer;
            isEnemyVisible = !isEnemyVisible;
            UIManager.UIInstance.EnableText();
        }
    }
}
