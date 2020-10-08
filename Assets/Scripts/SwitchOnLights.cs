using UnityEngine;

public class SwitchOnLights : MonoBehaviour
{
    [SerializeField]
    bool hasPlayerReached = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasPlayerReached)
        {
            GameManager.Instance.CanPlayerStart = false;
            hasPlayerReached = !hasPlayerReached;
        }     
    }
}
