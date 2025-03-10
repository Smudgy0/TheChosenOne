using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public bool isEnemyBullet = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player" && isEnemyBullet == true)
        {
            Destroy(this.gameObject);
        }
    }
}
