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
    private float _jumpForce = 7.5f;
    private Rigidbody2D _player;
    [SerializeField]
    private bool _canDoubleJump;
    [SerializeField]
    private float hInput;
    [SerializeField]
    AudioClip jumpAudioClip;
    AudioSource jumpAudio;
    bool lookingRight = true;
    SpriteRenderer sprite;
    [SerializeField]
    SpriteRenderer gun;
    float speed;
    [SerializeField]
    Animator switchAnimation;

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
        sprite = GetComponent<SpriteRenderer>();
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
    }

    private void FixedUpdate()
    {
        speed = Grounded ? _moveSpeed : _airSpeed;
        hInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(hInput, 0.0f);

        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (hInput > 0 && !lookingRight || hInput < 0 && lookingRight)
            Flip();
    }

    void Flip()
    {
        lookingRight = !lookingRight;
        sprite.flipX = !sprite.flipX;
        gun.GetComponent<SpriteRenderer>().flipY = !gun.GetComponent<SpriteRenderer>().flipY;
    }

    void Jump()
    {
        float force = _grounded ? _jumpForce : 5.0f;
        Vector2 _force = new Vector2(0.0f, force);
        _player.AddForce(_force, ForceMode2D.Impulse);
        jumpAudio.Play();
    }
}
