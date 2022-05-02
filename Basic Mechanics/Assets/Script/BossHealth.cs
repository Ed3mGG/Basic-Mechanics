using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public GameObject bossSlider; 

    public int bossHealth = 500;

    public BossHealthBar bossHealthBar;
    public DoorSpawn doorSpawn;
    
    public Animator animator;
    public AudioClip bossDeath;

    void Start()
    {
        bossHealthBar.SetMaxHealth(bossHealth); // Fais appel à la fonction pour mettre à jour la barre de pdv
        //bossSlider.SetActive(true); // activer dans le script TriggerBossFight
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T))
        {
            BossTakingDamage();
        }
    }

    public void BossTakingDamage(int damage = 250)
    {
        bossHealth -= damage;
        bossHealthBar.SetHealth(bossHealth);

        if (bossHealth <= 0)
        {
            animator.SetTrigger("Kill");
            StartCoroutine(BossDeath());
        }        
    }

    public void BossTakeDamage(int damage)
    {
        bossHealth -= damage;
        bossHealthBar.SetHealth(bossHealth);

        if (bossHealth <= 0)
        {
            animator.SetTrigger("Kill");
            StartCoroutine(BossDeath());
        }  
    }


    IEnumerator BossDeath()
    {
        yield return new WaitForSeconds(1f);
        bossSlider.SetActive(false);
        Destroy(gameObject);
        AudioManager.instance.PlayClipAt(bossDeath, transform.position);
        doorSpawn.TriggerDoorCredit();
    }
}
