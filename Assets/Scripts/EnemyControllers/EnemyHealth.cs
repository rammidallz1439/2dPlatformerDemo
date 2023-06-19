using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class EnemyHealth : HealthManager
{
    [SerializeField]
    private Transform healthBar;
    [SerializeField]
    private Animator anim;


    
    private void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (healthBar.localScale.x <= 0)
        {
            HealthManager.isDead = true;
            AnimationsManager.ChangeAnimations(AnimationsContainer.Enemy_Dead, anim);
            Destroy(this.gameObject, 1.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (healthBar.localScale.x >= 0)
            {

                healthBar.localScale = Vector2.Lerp(healthBar.localScale, new Vector2(-0.3f, 0.83f), 0.4f);
                
            }
            

        }
    }

   
}
