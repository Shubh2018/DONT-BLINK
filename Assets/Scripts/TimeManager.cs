using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float slowDownFactor = 0.05f;
    
    public void BulletTime()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void DefaultTime()
    {
        Time.timeScale = 1.0f;
    }
}
