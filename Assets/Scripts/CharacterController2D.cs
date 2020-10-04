using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5.0f;
    [SerializeField]
    private float _airSpeed = 2.5f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private float _jumpForce = 5.0f;
    private Rigidbody2D _player;
    [SerializeField]
    private bool _canDoubleJump;
    [SerializeField]
    private float hInput;
    [SerializeField]
    AudioClip jumpAudioClip;
    AudioSource jumpAudio;

    public float HInput
    {
        get
        {
            return hInput;
        }
    }
    float speed;
    bool bulletTime = false;

    public bool CanDoubleJump
    {
        get
        {
            return _canDoubleJump;
        }

        set
        {
            _canDoubleJump = value;
        }
    }

    public bool Grounded
    {
        get
        {
            return _grounded;
        }

        set
        {
            _grounded = value;
        }
    }

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        jumpAudio = GetComponent<AudioSource>();
        jumpAudio.clip = this.jumpAudioClip;
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && _grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && _canDoubleJump && !_grounded)
        {
            Jump();
            _canDoubleJump = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            bulletTime = !bulletTime;
        }
    }

    private void FixedUpdate()
    {
        speed = Grounded ? _moveSpeed : _airSpeed;
        hInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(hInput, 0.0f);
        Move(moveDirection, speed);

        /*if(hInput == 0)
            Teleport();   */     
    }

    void Move(Vector2 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void Jump()
    {
        Vector2 _force = new Vector2(0.0f, _jumpForce);
        _player.AddForce(_force, ForceMode2D.Impulse);
        jumpAudio.Play();
    }
}
