using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -15);
    }
}
