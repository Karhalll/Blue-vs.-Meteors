using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    [SerializeField] BoxCollider2D myFeet = null;


    Vector3 startingPosition;
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    bool isDead = false;

    private void Awake() 
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Start() 
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (isDead) { return; }
        Run();
        Jump();
        FlipSprite();
    }

    public void OnPlayerDeath()
    {
        myRigidbody.simulated = false;
        isDead = true;
    }

    public Vector3 GetStartingPosition()
    {
        return startingPosition;
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); 
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        bool isTouchingGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isTouchingPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));

        if (!isTouchingGround && !isTouchingPlatform) { return; }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
