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
    [SerializeField]
    float timeRemaining = 5.0f;
    [SerializeField]
    GameObject newPlatform;

    private void Start()
    {
        if(player != null)
            StartCoroutine(ChangeBGColor());   
    }

    IEnumerator ChangeBGColor()
    {
        while (true)
        {
            cam.backgroundColor = new Color(Random.value, Random.value, 255);

            yield return new WaitForSeconds(1.0f);

            cam.backgroundColor = Color.black;
            
            yield return new WaitForSeconds(Random.Range(6.0f, 11.0f));

            if(player.HInput == 0)
                StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        //timeRemaining = 5.0f;
        while(timeRemaining >= 0)
            timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            player.transform.position = new Vector3(player.transform.position.x - 5.0f, player.transform.position.y + Random.Range(-2.0f, 2.0f), 0.0f);
            timeRemaining = 5.0f;
            if(player.InstantiatePlatform && player.GoBack)
            {
                Instantiate(newPlatform, player.transform.position + new Vector3(0.0f, -0.5f, 0.0f), Quaternion.identity);
                player.AddPlatformsToList(newPlatform);
                yield return null;
            }       
            else if(player.GoBack)
                yield return null;
        }
    }
}
