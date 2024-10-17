using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Max height to jump")]
    [SerializeField] private float jumpHeight;
    [Tooltip("Horizontal speed")]
    [SerializeField] private float speed;
    [Tooltip("Collision layer")]
    [SerializeField] private LayerMask groundLayer;

    public float Speed { get => speed; set => speed = value; }
    
    public bool IsGrounded => isGrounded;
    public Rigidbody2D CharacterRb => characterRb;
    public Animator Animator => animator;
    public StateMachine StateMachine => stateMachine;

    private PlayerInput playerInput;
    private Rigidbody2D characterRb;
    private Animator animator;
    private StateMachine stateMachine;
    private bool isGrounded = true;
    private float verticalVelocity;

    void Awake()
    {
        characterRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

        stateMachine = new StateMachine(this);
    }

    void Start()
    {
        stateMachine.Initialize(stateMachine.idleState);
    }

    void Update()
    {
        stateMachine.Update();
    }

    void LateUpdate()
    {
        HandleJump();
        HandleMovement();
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (playerInput.IsAttacking)
        {
            stateMachine.TransitionTo(stateMachine.attackingState);
        }
    }

    public void ResetPosition(Vector2 positon)
    {
        gameObject.transform.position = positon;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = playerInput.InputVector;
        float horizontalVelocity = inputVector.x * speed;

        characterRb.velocity = new Vector2(horizontalVelocity, characterRb.velocity.y);

        //Rotate Sprite based on input
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        if (inputVector.x >= 1)
            playerSprite.flipX = false;
        else if (inputVector.x <= -1)
            playerSprite.flipX = true;
    }

    private void HandleJump()
    {
        // Check collision with layer
        Vector2 boxPosition = new Vector2(transform.position.x, transform.position.y - 1f);
        Vector2 boxSize = new Vector2(1f, 0.1f);

        RaycastHit2D hit = Physics2D.BoxCast(boxPosition, boxSize, 0f, Vector2.down, 0f, groundLayer);
        isGrounded = hit.collider != null;

        if (isGrounded)
        {
            if (playerInput.IsJumping)
            {
                characterRb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                playerInput.IsJumping = false; // Avoid continuous jumping
            }
        }
    }
}
