using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
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

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject SpawnPoint;

    bool canIdle;
    #endregion


  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canIdle = true;
    }
    private void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canIdle = false;
            AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Shoot, anim);
           
            Instantiate(bullet, SpawnPoint.transform.position, Quaternion.identity);
            Invoke("PlayIdle", 1.5f);
        }
        else
        {
            canIdle = true;
        }

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
            AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Run, anim);
        }
        else if(!isGrounded)
        {
            AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Jump, anim);
        }
        else if(isGrounded && canIdle)
        {
            AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Idle, anim);
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

    public void PlayIdle()
    {
        AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Idle, anim);
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
