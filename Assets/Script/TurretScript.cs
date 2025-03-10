using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public Transform player; // references the player under the value "player" to allow the turret to track the players current postion (when they are in range of its circle collider).
    public Transform firingTransform; // this value is for an empty GameObject to make the turrets barrel rotation more natural
    public Transform firingPostion; // this value is sued to call upon the turrets "FiringPos" object which rotates along with the "firingTransform" meaning that it will allways be aimed at the players postion

    public float shootingDelay = 1; // this value to to set how many seconds the turret will take to fire again.
    public float shootingPower = 1; // this value is used to set the force the bullet is fired at the player.

    public float BulletTimer = 1;

    public GameObject bulletPrefab; // this value is used to get the selected prefab or object to fire at the player such as a bullet with the tag "Death".
    bool firing; // a true or false value telling the turret if it can fire at the player or not.

    void Update()
    {
        if (player) //checks if there is any value in the player transform.
        {
            Vector2 distance = player.position - transform.position; // checks the distance of the player on the x and y axis and gets the values to track the player
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg; // this line uses the values of the above lines to get the angle needed to aim at the player
            firingTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // this line then uses the math above to aim the barrel and firingPos at the player with the empty GameObject as a rotator.

            if (!firing)
            {
                StartCoroutine(ShootDelay());
                // after it fires at the player it will run the "ShootDelay" function
            }
        }
    }


    IEnumerator ShootDelay()
    {
        firing = true; // sets the firing bool to true
        GameObject bulletClone = Instantiate(bulletPrefab, firingPostion.position, firingPostion.rotation); // uses the rotation calculated earlyier to rotated the bullet prefab to be aimed towards the player 
        bulletClone.GetComponent<Rigidbody2D>().linearVelocity = firingPostion.right * shootingPower; // gets the value for the velcoity it will be fired at and times it by the shooting power
        Destroy(bulletClone, BulletTimer); // destroys the bullet clone after a set time
        yield return new WaitForSeconds(shootingDelay); // waits to fire again based on how the value of the "shootingDelay"
        firing = false; // sets the firing bool to false
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.transform;
        } // if the player enter the raidus of the turret the turret will begin tracking the player
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = null;
        } // if the player leaves the raidus of the turret the turret will stop tracking the player
    }
}
