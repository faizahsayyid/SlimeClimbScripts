using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    //Reference Code:
    //By Brackey's: https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
    //The youTube vid: https://www.youtube.com/watch?v=dwcT-Dch0bA&t=329s 

    //Serialize adds a private variable to the unity inspector

    [SerializeField] private Transform groundCheck;     //Location, to see if player is on the ground
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; //How much to smooth out the movement
    [SerializeField] private LayerMask m_WhatIsGround;

    public bool isPlayerFacingLeft = true;


    //Player stuffs
    private Vector3 playerVelocity = Vector3.zero;
    private Rigidbody2D playerRigidbody;
    private SlimeBodyMass slime;

    //Ground Check 
    private bool grounded;  //Whether the player is on the ground 
    const float groundedRadius = 0.2f;  //how far the ground can be from the player for the player to be grounded

    //Add this header in the unity inspector
    [Header("Events")]
    [Space]

    //UnityEvent: A zero argument persistent callback that can be saved with the Scene.
    //This saves what's happening in the scene in regard to grounded
    public UnityEvent OnLandEvent;

    //Movement Variables
    [Header("Movement Variables")]
    [Space]

    public float runSpeed = 50f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float doubleJumpVelocity = 20f;


    private float horizontalMove = 0f;
    private bool m_doubleJump = false;
    private bool m_jump = false;
    public bool canDoubleJump = true;

    // Animator Stuff
    [Header("Animation")]
    [Space]
    public Animator animator;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        slime = GetComponent<SlimeBodyMass>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    private void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetButtonDown("Jump") && grounded)
        {
            m_jump = true;
            animator.SetTrigger("Jump");
        }
        else if (Input.GetButtonDown("Jump") && !grounded)
        {
            m_doubleJump = true;
            animator.SetTrigger("Jump");
        }


        animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
        //Debug.Log(playerVelocity.y);

        if (!canDoubleJump)
        {
            StartCoroutine(WaitForNextDouble());
        }

    }

    IEnumerator WaitForNextDouble()
    {
        //Debug.Log("Waiting for next double jump");

        yield return new WaitForSeconds(0.5f);

        canDoubleJump = true;
    }


    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                    animator.SetTrigger("Land");
                }
            }
        }

        Move(horizontalMove * Time.fixedDeltaTime, m_jump, m_doubleJump);
        m_jump = false;
        m_doubleJump = false;

    }

    public void Move(float move, bool jump, bool doubleJump)
    {
        //Add to velocity
        Vector3 targetVelocity = new Vector2(move * 100f, playerRigidbody.velocity.y);
        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref playerVelocity, movementSmoothing);


        // If the input is moving the player right and the player is facing left...
        if (move < 0 && !isPlayerFacingLeft)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move > 0 && isPlayerFacingLeft)
        {
            Flip();
        }

        //Jumping
        if (grounded && jump)
        {
            grounded = false;
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
        }
        else if (!grounded && doubleJump && canDoubleJump && !slime.massTooLow)
        {
            //playerRigidbody.AddForce(new Vector2(0f, doubleJumpForce));
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, doubleJumpVelocity); //+ doubleJumpForce);

            slime.LoseBodyMass();
            canDoubleJump = false;
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isPlayerFacingLeft = !isPlayerFacingLeft;

        transform.Rotate(0f, 180f, 0f);
    }

}
