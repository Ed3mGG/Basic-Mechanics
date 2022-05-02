using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public ImpactEffect destroyImpactEffect;
    public AudioClip hitSoundEnnemis;
    public AudioClip hitSoundFondation;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Ennemis"))
        {
            Ennemis ennemis = collision.GetComponent<Ennemis>();
            if (ennemis != null)
            {
                ennemis.TakeDamage(damage);
            }
            //Instantiate(impactEffect, transform.position, transform.rotation);
            StartCoroutine(Hit());
            AudioManager.instance.PlayClipAt(hitSoundEnnemis, transform.position);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Fondation"))
        {
            //Instantiate(impactEffect, transform.position, transform.rotation);
            StartCoroutine(Hit());
            AudioManager.instance.PlayClipAt(hitSoundFondation, transform.position);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Boss"))
        {
            BossHealth boss = collision.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.BossTakeDamage(damage);
            }
            //Instantiate(impactEffect, transform.position, transform.rotation);
            StartCoroutine(Hit());
            AudioManager.instance.PlayClipAt(hitSoundEnnemis, transform.position);
            Destroy(gameObject);
        }
    }

    IEnumerator Hit() 
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            destroyImpactEffect.DestroyHit();
        }
    


    
}
