using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;
    public int damageOnCollision = 33;

    //Permet de stocker les valeurs de FindGameObjectWithTag une fois au lancement
    private void Awake() 
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }
  
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        //Replace le personnage au GameObject(avec son tag) PlayerSpawn avec une coroutine
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;

        // Fais appel au script PlayerHealth pour faire des dégats au joueur
        yield return new WaitForSeconds(0.75f);
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); 
        playerHealth.TakeDamage(damageOnCollision);
    }
}
