
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    
    public AudioClip jumpSound;

    public bool isJumping;
    public bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    public Rigidbody2D rb;
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    private float horizontalMovement;
    private float verticalMovement;

    public static PlayerMovement instance;

    //Permet d'acceder au script PlayerMovement depuis n'importe où (appelé Singletone)
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }
        instance = this;
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing) // Si la cible est au sol, permet de le saut
        {
            isJumping = true;
        }

        // Nouvelle action du flip
        if (horizontalMovement > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalMovement < 0 && isFacingRight)
        {
            Flip();
        }

        //Flip(rb.velocity.x); // Anicenne action de flip

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        float characterVelocityClimb = Mathf.Abs(rb.velocity.y);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
        animator.SetFloat("Climb", characterVelocityClimb);
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime; // D�placement suivant l'axe X

        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime; // D�placement suivant l'axe Y

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers); // Permet de d�tecter si la cible est au sol

        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if(!isClimbing) //déplacement horizontal
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping) // M�canique de saut
            {
            rb.AddForce(new Vector2(0f, jumpForce));
            AudioManager.instance.PlayClipAt(jumpSound, transform.position);
            isJumping = false;
            }
        }
        else //déplacement vertical
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
        

    }


    /*void Flip(float _velocity) // Calcul de la vitesse pour le flip du personnage (0+ droite 0- gauche) qui utilise le sprite renderer
    {
        if (_velocity > 0.1f)
        {
            //spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            //spriteRenderer.flipX = true;
        }
    }*/

    private void Flip() // nouvelle version qui rotate le personnage ainsi que des childrens, permettant notamment le tir
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    */
}
