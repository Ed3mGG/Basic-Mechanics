using UnityEngine;

public class SnakeWeakspot : MonoBehaviour
{
    public GameObject objectToDestroy; // cr�ation d'un objet qui permet de d�truire la cible sans avoir � utiliser la version bourrin .parent.parent
    public AudioClip killSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // Permet de d�truire l'objet si un autre objet avec le tag "Player" entre en contact
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            Destroy(objectToDestroy);
        }
    }
}
