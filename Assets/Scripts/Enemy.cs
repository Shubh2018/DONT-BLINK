using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform gunholder;
    Vector3 dirToShoot;
    [SerializeField]
    float _bulletSpeed = 60.0f;
    [SerializeField]
    GameObject bulletprefab;
    [SerializeField]
    Transform bulletSpawn;
    [SerializeField]
    float distance = 10.0f;  

    float _nextTimeToShoot = 0.0f;
    [SerializeField]
    float fireRate = 0.1f;
    //[SerializeField]
    //ParticleSystem bloodScatter;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        dirToShoot = -(player.position - gunholder.position);
        float rotZ = Mathf.Atan2(dirToShoot.y, dirToShoot.x) * Mathf.Rad2Deg;
        gunholder.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ));
        if (Vector3.Distance(player.position, transform.position) < distance)
            Shoot(rotZ);
    }

    void Shoot(float rotZ)
    {
        if(_nextTimeToShoot < Time.time)
        {
            _nextTimeToShoot = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletprefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ)));
            bullet.GetComponent<Rigidbody2D>().velocity = -dirToShoot.normalized * _bulletSpeed * Time.deltaTime;
        }
    }
}
