using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float RunSpeed = 5.5f;
    [SerializeField] float JumpHeight = 1.5f;

    private Rigidbody2D PlayerRigidbody;

    private Vector2 movementDirection;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        movementDirection = value.ReadValue<Vector2>(); // Uses the unity Input system to read a radius value of where the player is inputing, so pressing "A" would set this value to -1 meaning the player would move left, 0 if no input is dectected and if "D" is selected the value is set to 1, moving the player right.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump(); // The OnJump code checks if the player has press the spacebar with the "context.performed" statement and if its true the player jumps, else nothing happens.
        }
    }

    void Jump()
    {
        /*if (isGrounded)
        {
            PlayerRigidbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            // this code first checks if the player is grounded as they press the jump key (space) and if its true it will and a postiive Y force to the player, making their player jump, else if "isGrounded" is not true the player will not have any force applied to them.
        }*/

        PlayerRigidbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        PlayerRigidbody.linearVelocity = new Vector2(movementDirection.x * RunSpeed * Time.deltaTime, PlayerRigidbody.linearVelocityY);
    }
}
