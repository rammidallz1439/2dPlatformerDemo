using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthManager
{
   
  
    [SerializeField]
    private Slider slider;
    
    private void Start()
    {
        slider.value = health;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (slider != null)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
               
                StartCoroutine(SlowDownDecrease());
                canAttck = true;
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttck = false;
    }
    IEnumerator SlowDownDecrease()
    {
        DecreaseHealth(d_Health);
        slider.value = health;
        yield return new WaitForSeconds(0.5f);
        
        if (canAttck)
        {
            StartCoroutine(SlowDownDecrease());
        }
       
    }
    
}
