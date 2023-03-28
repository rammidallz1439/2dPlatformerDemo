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

    Vector2 movement;
    
    private Rigidbody2D rb;
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
        Movement(movement);
    }
    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, movement.y).normalized;
        if (horizontal!= 0)
        {
            anim.SetInteger("State",1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
    }

    void Movement(Vector2 move)
    {
        rb.velocity = move * speed;

    }
}
