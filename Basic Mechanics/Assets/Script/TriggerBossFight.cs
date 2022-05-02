using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    public Animator animator;
    public GameObject bossSlider;

    //Si collision détectée, (animator)isTrigger = true
    private void OnTriggerEnter2D(Collider2D collision)
   {       
       if(collision.CompareTag("Player"))
       {
           animator.SetTrigger("isTrigger");
           bossSlider.SetActive(true);
           Destroy(gameObject);
       }
   }  
    
}
