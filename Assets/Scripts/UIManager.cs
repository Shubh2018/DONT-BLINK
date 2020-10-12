using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _uiInstance;

    public static UIManager UIInstance
    {
        get
        {
            if (_uiInstance == null)
                Debug.Log("UIManager DNE");
            return _uiInstance;
        }
    }

    [SerializeField]
    private Text dontBlinkText;
    Scene _currentScene;
    [SerializeField]
    Canvas winText;
    [SerializeField]
    Canvas loseText;
    [SerializeField]
    Text killCount;

    private void Awake()
    {
        _uiInstance = this;
        _currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        winText.enabled = false;
        loseText.enabled = false;
    }

    private void Update()
    {
        if (GameManager.Instance.IsEnemyVisible)
            dontBlinkText.text = "DONT-BLINK";

        DisplayConcludeText();
            
        killCount.text = "Kills: " + GameManager.Instance.NoOfEnemy.ToString();
    }

    public void NextScene()
    {
        if (_currentScene.buildIndex == 6)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(_currentScene.buildIndex + 1);
    }

    public void LoadStage(int index)
    {
        SceneManager.LoadScene(index);
    }

    void DisplayConcludeText()
    {
        if(GameManager.Instance.IsPlayerDead)
        {
            loseText.enabled = true;
            dontBlinkText.enabled = false;
        }

        else if(GameManager.Instance.HasWon)
        {
            winText.enabled = true;
            dontBlinkText.enabled = false;
        }

        else if(GameManager.Instance.IsPlayerDead && GameManager.Instance.HasWon)
        {
            SceneManager.LoadScene(_currentScene.buildIndex);
        }
    }

    public void Help()
    {
        SceneManager.LoadScene(7);
    }

    public void EnableText()
    {
        dontBlinkText.enabled = !dontBlinkText.enabled;
    }

    public void Retry()
    {
        SceneManager.LoadScene(_currentScene.buildIndex);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
