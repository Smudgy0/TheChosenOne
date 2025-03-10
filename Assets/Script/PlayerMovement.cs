using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float RunSpeed = 5.5f;
    [SerializeField] float JumpHeight = 1.5f;

    public float groundCheckRadius;
    public Transform groundCheckObject;
    public LayerMask groundMask;
    public Collider2D isGrounded;

    public int HP = 3;

    public Transform PlayerPos;
    public Transform RespawnPos;

    private Rigidbody2D PlayerRigidbody;

    private Vector2 movementDirection;

    public int PlayerScore = 0;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        movementDirection = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            PlayerRigidbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            // this code first checks if the player is grounded as they press the jump key (space) and if its true it will and a postiive Y force to the player, making their player jump, else if "isGrounded" is not true the player will not have any force applied to them.
        }
    }

    private void FixedUpdate()
    {

        if(HP == 0)
        {
            Respawn();
        }

        PlayerRigidbody.linearVelocity = new Vector2(movementDirection.x * RunSpeed * Time.deltaTime, PlayerRigidbody.linearVelocityY);
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, groundMask);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScoreRewarder")
        {
            Destroy(collision.gameObject);
            PlayerScore = PlayerScore + 1;
        }

        if (collision.tag == "Death")
        {
            Respawn();
        }

        if (collision.tag == "CheckPoint")
        {
            RespawnPos.position = collision.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            HP = HP - 1;
        }

        if (collision.gameObject.tag == "ScoreRewarder")
        {
            Destroy(collision.gameObject);
            PlayerScore = PlayerScore + 1;
        }
    }

    void Respawn()
    {
        PlayerPos.position = RespawnPos.position;
        HP = 3;
    }
}
