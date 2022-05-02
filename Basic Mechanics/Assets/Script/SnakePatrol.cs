using UnityEngine;

public class SnakePatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoint;
    public SpriteRenderer graphics;
    public int damageOnCollision = 20;


    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        graphics.flipX = !graphics.flipX; // Permet de flip le snake au lancement
        target = waypoint[0]; 
    }

    
    void Update()
    {
        // Permet le d�placement en fonction de la direction en soustrayant la position actuelle
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        // Permet d'�tablir la destination du snake sous forme de waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoint.Length; // Permet de remettre � 0 la destination si elle d�passe les valeurs possibles
            target = waypoint[destPoint];
            graphics.flipX = !graphics.flipX; // Permet de flip � chaque changement de sens
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // G�re la partie collision avec le joueur, les d�gats inflig�s
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); // Fais appel au script PlayerHealth
            playerHealth.TakeDamage(damageOnCollision);

        }
    }
}
