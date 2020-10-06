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

    void Start()
    {
        Camera.main.backgroundColor = new Color(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        if(StartTimer)
            Timer();
    }

    void Timer()
    {   
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Camera.main.backgroundColor = Color.black;
            timer = 2.5f;
            StartTimer = false;
        }
    }
}
