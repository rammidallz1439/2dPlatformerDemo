using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletSpeed = 2;

    void Start()
    {
       
        Destroy(gameObject,2);
        FlipBullet();


    }


    private void FlipBullet()
    {
        if (!PlayerController.isFlipped)
        {
         
            transform.localScale = new Vector2(0.5f, 0.5f);

        }
        else
        {

            transform.localScale = new Vector2(-0.5f, 0.5f);

        }
    }
   
    private void Update()
    {
        if (transform.localScale.x < 0)
        {
            transform.position += new Vector3(-bulletSpeed, 0f, 0f) * Time.deltaTime;
        }
        else
            transform.position += new Vector3(bulletSpeed, 0f, 0f) * Time.deltaTime;




    }

}
