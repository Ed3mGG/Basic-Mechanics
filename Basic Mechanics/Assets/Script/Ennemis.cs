using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public AudioClip killSound;

    public int health = 100;

    //public GameObject deathEffect;
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        AudioManager.instance.PlayClipAt(killSound, transform.position);
        Destroy(gameObject);
    }
}
