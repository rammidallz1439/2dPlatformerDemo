using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region private Fields
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private int speed;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float jumpForce;

    Vector2 movement;   
    private Rigidbody2D rb;

    bool isGrounded;
   
    #endregion


  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PlayerMovement();
     
      

    }
    private void FixedUpdate()
    {
        //this moves player
        Movement(movement);

        if (Input.GetKeyDown(KeyCode.S))
        {
            isGrounded = false;
            Jump();

        }
    }
   
    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, movement.y).normalized;
       
        if (horizontal != 0 && isGrounded)
        {
            anim.SetInteger("State",1);
        }
        else if(!isGrounded)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 0);
        }


        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(horizontal !=0 && horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
     
    }
    void Jump()
    {
        if (rb.velocity.y == 0)
        {
           
            rb.AddForce(Vector2.up * jumpForce);
        }
        else
        {
            isGrounded = false;
        }
    }

    void Movement(Vector2 move)
    {
        rb.velocity = move * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
