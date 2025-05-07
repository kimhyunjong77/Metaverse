using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected AnimationHandler animationHandler;

    [SerializeField] private SpriteRenderer characterRenderer;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(movementDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)
    {
        direction *= 5;
        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    private void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }

    protected void Rotate(Vector2 direction)
    {
        
        if (movementDirection == Vector2.zero)
            return;

        if (movementDirection.x < 0)
        {
            characterRenderer.flipX = true;
        }
        else if(movementDirection.x > 0)
        {
            characterRenderer.flipX = false;
        }
    }
}
