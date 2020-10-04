using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    bool deleteFloor = false;

    private void Update()
    {
        if (deleteFloor)
            Destroy(this.gameObject, 3.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            deleteFloor = false;
    }

   /* private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            deleteFloor = true;
    }*/
}
