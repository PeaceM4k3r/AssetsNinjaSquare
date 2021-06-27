using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Horizontal Movement
    public float speedMovement;
    private Rigidbody2D thisRigidBody2D;
    //Jump
    public float jumpForce;
    public bool isGrounded;
    //doubleJump
    public bool doubleJump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    
    //Respawn
    public Vector2 respawnCoords;
    //Animations
    private Animator thisAnimator;
    //LevelManager
    private LevelManager theLevelManager;

    //Attacks

    //Shuriken
    public GameObject shurikenLeft;
    public GameObject shurikenRight;



    // Start is called before the first frame update
    void Start()
    {
        //Movement
        thisRigidBody2D = GetComponent<Rigidbody2D>();
        //Respawn
        respawnCoords = gameObject.transform.position;
        //Animations
        thisAnimator = GetComponent<Animator>();
        //LevelManager
        theLevelManager = FindObjectOfType<LevelManager>();


    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            doubleJump = true;
        }


        //Horizontal Movement
        //to Right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //move the sprite to right
            thisRigidBody2D.velocity = new Vector2(speedMovement, thisRigidBody2D.velocity.y);
            //make the sprite "look" to right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //to Left
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //move the sprite to left
            thisRigidBody2D.velocity = new Vector2(-speedMovement, thisRigidBody2D.velocity.y);
            //make the sprite "look" to left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //stay Idle
        else
        {
            thisRigidBody2D.velocity = new Vector2(0f, thisRigidBody2D.velocity.y);
        }
        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            thisRigidBody2D.velocity = new Vector2(thisRigidBody2D.velocity.x, jumpForce);
        }
        //doubleJump
        if (Input.GetButtonDown("Jump") && (!isGrounded && doubleJump))
        {
            thisRigidBody2D.velocity = new Vector2(thisRigidBody2D.velocity.x, jumpForce);
            doubleJump = false;
        }





        if (Input.GetButtonDown("Fire1") && transform.localScale.x == 1)
        {
            Instantiate(shurikenRight, transform.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire1") && transform.localScale.x == -1)
        {
            //bulletOrigin = new Vector3(transform.position.x - 0.6f, transform.position.y,transform.position.z);
            Instantiate(shurikenLeft, transform.position, transform.rotation);
        }


        //AnimatorTransitionsParameters
        thisAnimator.SetFloat("moveSpeed", Mathf.Abs(thisRigidBody2D.velocity.x));
        thisAnimator.SetBool("isGrounded", isGrounded);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillZone"))
        {
            theLevelManager.HurtPlayer(6);
        }
        if(collision.gameObject.CompareTag("CheckPoints"))
        {
            respawnCoords = collision.transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MovingPlatforms"))
        {
            transform.parent = collision.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatforms"))
        {
            transform.parent = null;
        }
    }
}
