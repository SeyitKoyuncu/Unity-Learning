using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 3;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] float climbSpeed = 5;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    Vector2 moveInput;
    Rigidbody2D playerRB;
    Animator playerAnimator;
    BoxCollider2D playerCollider;
    BoxCollider2D playerFeetCollider;
    float gravity;

    bool isAlive = true;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponents<BoxCollider2D>()[0];
        playerFeetCollider = GetComponents<BoxCollider2D>()[1];
        gravity = playerRB.gravityScale;
    }

    void Update()
    {
        if(!isAlive) { return;  };
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; };
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; };
        if (value.isPressed && playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerRB.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; };
        Instantiate(bullet, gun.position, transform.rotation);
    }

    void ClimbLadder()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            Vector2 climbVelocity = new Vector2(playerRB.velocity.x, moveInput.y * climbSpeed);
            bool climbingAnimation = Mathf.Abs(playerRB.velocity.y) > Mathf.Epsilon;
            playerAnimator.SetBool("isClimbing", climbingAnimation);
            playerRB.velocity = climbVelocity;
            playerRB.gravityScale = 0;
        }

        else
        {
            playerAnimator.SetBool("isClimbing", false);
            playerRB.gravityScale = gravity;
        }
    }

    void Run()
    {
        if (!isAlive) { return; };
        //with moveInput.x * runSpeed enable the mvoe left and right
        //with playerRB.velocity.y disable the move up and down
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRuning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        //Mathf.Epsilon is very smaller float but not 0 
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(playerRB.velocity.x), 1f);;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        playerAnimator.SetTrigger("Dying");
        playerRB.velocity = deathKick;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
}
