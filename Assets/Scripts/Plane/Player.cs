using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;

    bool isFlap = false;
    public bool godMode = false;

    GameManager gameManager = null;

    float defaultGravityScale;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Found Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Found Rigidbody");

        defaultGravityScale = _rigidbody.gravityScale;
        _rigidbody.gravityScale = 0;
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameStarted || isDead)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isFlap = true;
        }
    }

    public void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameStarted || isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y = flapForce; 
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode || isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        gameManager.GameOver();
    }

    public void EnableGravity()
    {
        _rigidbody.gravityScale = defaultGravityScale;
    }
}