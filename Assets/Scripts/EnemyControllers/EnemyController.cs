using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float speed;

    [SerializeField]
    public GameObject enemyBody;

    private GameObject player;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = enemyBody.GetComponent<Animator>();

        player = GameObject.Find("Player");

        
    }

    private void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position,player.transform.position);

        float pos = transform.position.x ;
        if (player.transform.position.x > pos)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1);
        }

        if (dist < 4 && dist > 1)
        {
            Vector2 move = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.position = move;


            if (transform.position.x != 0 )
            {
                AnimationsManager.ChangeAnimations(AnimationsContainer.Enemy_Walk, anim);
            }

        }
        else if (dist <=1 )
        {
            AnimationsManager.ChangeAnimations(AnimationsContainer.Enemy_Attack, anim);
        }
        else
        {
            AnimationsManager.ChangeAnimations(AnimationsContainer.Enemy_Idle, anim);
        }




    }


}
