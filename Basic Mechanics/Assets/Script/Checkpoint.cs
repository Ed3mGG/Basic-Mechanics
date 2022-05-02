using UnityEngine;

public class Checkpoint : MonoBehaviour
{    

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint = transform.position;
            /*Destroy(gameObject); //Supprime l'instance */
            gameObject.GetComponent<BoxCollider2D>().enabled = false; //Desactive le BoxCollider de l'instance
        }
        
    }
}
