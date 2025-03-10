using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    public Transform BoxPOS;
    public Transform BoxRespawnPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Respawn();
        }
    }

    void Respawn()
    {
        BoxPOS.position = BoxRespawnPos.position;
        BoxPOS.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
    }
}
