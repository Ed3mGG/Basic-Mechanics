using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer spriteRenderer;

    public bool isFlipped = true;

    public void LookAtPlayer()
    {
        if(transform.position.x < player.position.x && !isFlipped)
        {
            Flip();
        }
        else if(transform.position.x > player.position.x && isFlipped)
        {
            Flip();
        }
    }

    private void Flip() 
    {
        isFlipped = !isFlipped;

        transform.Rotate(0f, 180f, 0f);
    }
}
