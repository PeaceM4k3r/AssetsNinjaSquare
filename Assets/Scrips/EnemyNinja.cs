using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNinja : MonoBehaviour
{
    //Physics
    public Rigidbody2D rigi;
    public bool onGround;
    public float jumpForce;
    public float checkGround;
    public LayerMask whatIsGround;

    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        onGround = Physics2D.OverlapCircle(transform.GetChild(0).position, checkGround, whatIsGround);




        AllAnimations();
    }


    



    void Jump()
    {
        if (onGround)
        {
            rigi.velocity = new Vector2(rigi.velocity.x,jumpForce);
            onGround = false;
        }
    }


    void AllAnimations()
    {
        //Jump Animation
        anima.SetBool("onGround", onGround);
        //Run Animation
        //anima.SetFloat("speed", );
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("detectado");

            if (!collision.GetComponent<PlayerController>().isGrounded)
            {
                Debug.Log("Player Saltando");
                Jump();
            }


        }
    }

}
