using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public AudioClip hitSound;

    public float invincibilityTimeAfterHit = 1f;
    public bool isInvincible = false;
    public float invincibilityFlashDelay = 0.15f;
    public SpriteRenderer graphics;

    public static PlayerHealth instance;

    //Permet d'acceder au script PlayerHealth depuis n'importe où (appelé Singletone)
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth; // Définis la barre du joueur au max
        healthBar.SetMaxHealth(maxHealth); // Fais appel à la fonction pour mettre à jour la barre de pdv
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        } 
    }
    
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage; // Peut aussi s'écrire currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);

            // On vérifie si le joueur a suffisemment de pdv
            if(currentHealth  <= 0)
            {
                Death();
                return;
            }
            else
            {
                isInvincible = true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }

            
        }
    }

    public void Death()
    {
        //Bloquer les mouvements du personnage, jouer l'animation de mort, empêcher les intéractions physique avec les autres éléments de la scène
        Debug.Log("Le joueur est éliminé.");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void HealingPlayer(int heals)
    {
        if((currentHealth + heals) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heals;
        }

        healthBar.SetHealth(currentHealth); 
    }   

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // Désactive le visuel du joueur
            yield return new WaitForSeconds(invincibilityFlashDelay); // Attends 1 seconde
            graphics.color = new Color(1f, 1f, 1f, 1f); // Réactive le visuel du joueur
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }  
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
