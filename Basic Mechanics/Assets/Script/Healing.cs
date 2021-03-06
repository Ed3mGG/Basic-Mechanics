using UnityEngine;

public class Healing : MonoBehaviour
{

    public int healthPoints;

    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(pickUpSound, transform.position);
                PlayerHealth.instance.HealingPlayer(healthPoints);
                Destroy(gameObject);
            }
            
        }
    }
}
