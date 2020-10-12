using UnityEngine;

public class AimAssist : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField]
    private GameObject _gunHolder;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private GameObject _bulletSpwan;
    [SerializeField]
    private float _bulletSpeed = 60.0f;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextTimeToFire = 0.0f;
    [SerializeField]
    AudioClip shoot;
    [SerializeField]
    AudioSource shootAudio;

    private void Start()
    {
        shootAudio.clip = shoot;
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - _gunHolder.transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _gunHolder.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ);

        RaycastHit2D hit = Physics2D.Raycast(_bulletSpwan.transform.position, mousePosition);

        if (Input.GetMouseButtonDown(0) && Vector3.Distance(direction, _gunHolder.transform.position) > 4)
        {
            Debug.DrawRay(_bulletSpwan.transform.position, mousePosition, Color.red);
            if (hit)
            {
                Debug.Log(hit.transform.name);
            }

            if (_nextTimeToFire < Time.time)
            {
                _nextTimeToFire = Time.time + _fireRate;

                GameObject bullet = Instantiate(_bulletPrefab, _bulletSpwan.transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ)));
                bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * _bulletSpeed * Time.unscaledDeltaTime;
                shootAudio.Play();
            }
        }
    }
}
