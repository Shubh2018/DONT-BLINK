﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject parentObject;
    [SerializeField]
    ParticleSystem bloodScatter;
    [SerializeField]
    CharacterController2D player;

    void Start()
    {
        parentObject = GameObject.Find("BulletHolder");
        this.gameObject.transform.parent = parentObject.transform;
    }

    private void OnEnable()
    {
        Destroy(this.gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
            Destroy(this.gameObject);

        if(collision.transform.CompareTag("enemy"))
        {
            ParticleSystem blood = Instantiate(bloodScatter, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            blood.Play();
            Destroy(blood, 5.0f);
        }

        if (collision.transform.CompareTag("Player"))
        {
            ParticleSystem blood = Instantiate(bloodScatter, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            blood.Play();
            Destroy(blood, 5.0f);
            GameManager.Instance.IsPlayerDead = true;
        }
    }
}
