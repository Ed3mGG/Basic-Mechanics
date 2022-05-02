using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.moveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    public IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.moveSpeed -= speedGiven;
    }

    public void AddJumpForce(int jumpForceGiven, float jumpForceDuration)
    {
        PlayerMovement.instance.jumpForce += jumpForceGiven;
        StartCoroutine(RemoveJumpForce(jumpForceGiven, jumpForceDuration));
    }

    public IEnumerator RemoveJumpForce(int jumpForceGiven, float jumpForceDuration)
    {
        yield return new WaitForSeconds(jumpForceDuration);
        PlayerMovement.instance.jumpForce -= jumpForceGiven;
    }
   
}
