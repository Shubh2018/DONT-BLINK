using System.Collections;
using System.Collections.Generic;
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
    Camera cam;
    [SerializeField]
    CharacterController2D player;

    private void Start()
    {
        if(player != null)
            StartCoroutine(ChangeBGColor());   
    }

    IEnumerator ChangeBGColor()
    {
        while (true)
        {
            cam.backgroundColor = new Color(Random.value, Random.value, Random.value);

            yield return new WaitForSeconds(1.0f);

            cam.backgroundColor = Color.black;
            
            yield return new WaitForSeconds(Random.Range(6.0f, 11.0f));
        }
    }
}
