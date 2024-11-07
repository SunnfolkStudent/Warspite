using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;

    [Header("GroundCheck")]
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f,0.2f);
    
    [Header("Death")]
    public bool dead = false;
    public float deathTimer = 1.5f;
    
    [Header("Audio")]
    public AudioClip deathSounds;
    public AudioClip[] jumpSounds;
    public AudioClip[] takeDamageSounds;
    
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    
    private Animator _animator;

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
            //_audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        }
        print(whatIsGround);
        
        UpdateAnimation();
        //FaceDirection();

        if (dead)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
    }
    
    private void UpdateAnimation()
    {
        if (playerIsGrounded)
        {
            if (_rigidbody2D.linearVelocity.x == 0)
            {
                _animator.Play("Player_Idle");
            }
            else
            {
                _animator.Play("Player_Walk");
            }
        }
        else
            {
                if (_rigidbody2D.linearVelocity.y > 0)
                {
                    _animator.Play("Player_Jump");
                }
                else
                {
                    _animator.Play("Player_Fall");
                }
            }
        }

    private void FaceDirection()
    {
        if (_rigidbody2D.linearVelocity.x > 0)
        {
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            if (_rigidbody2D.linearVelocity.x < 0)
            {
                transform.localScale = new Vector2(-1,1);
            }
        }
    }


    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
    }
    
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Death"))
        {
            dead = true;
            moveSpeed = 0;
            jumpSpeed = 0;
        }
    }
}