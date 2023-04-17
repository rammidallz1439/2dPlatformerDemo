using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletSpeed = 2;

    void Start()
    {
       
        Destroy(gameObject,2);
    }
   
    private void LateUpdate()
    {
        transform.position += new Vector3(bulletSpeed, 0f, 0f) * Time.deltaTime;
    }

}
