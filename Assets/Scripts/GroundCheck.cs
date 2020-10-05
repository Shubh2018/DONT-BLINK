using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    CharacterController2D characterController;

    private void Start()
    {
        characterController = gameObject.transform.parent.GetComponent<CharacterController2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("floor"))
        {
            characterController.Grounded = true;
            characterController.CanDoubleJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("floor"))
            characterController.Grounded = false;
        characterController.CanDoubleJump = true;
    }
}
