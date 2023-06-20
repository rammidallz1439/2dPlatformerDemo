using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;
public class PlayerHealth : HealthManager
{
   
  
    [SerializeField]
    private Slider slider;

    private Animator anim;

    private void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        slider.value = health;
        UiManager.instance.GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (slider.value <= 0)
        {
            AnimationsManager.ChangeAnimations(AnimationsContainer.Player_Dead, anim);
            UiManager.instance.GameOverPanel.SetActive(true);
            Invoke("DestroyPlayer", 1f);
            canAttck = false;
        }
    }

    public void DestroyPlayer()
    {
        transform.gameObject.SetActive(false);
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
