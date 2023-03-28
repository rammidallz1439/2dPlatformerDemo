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
    Rigidbody2D rb;
    #endregion


  
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

    }

    void Movement(Vector2 move)
    {
        rb.velocity = move * speed;
    }
}
