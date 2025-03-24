using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool toggle;
    public float platformSpeed;

    public Transform[] movementPoints;

    private void Start()
    {
        transform.position = movementPoints[0].position;
    }
    // Update is called once per frame
    void Update()
    {
        //Get the distance between the current platform and the movement points, check if it's close then set toggle to true/false
        if (Vector2.Distance(transform.position, movementPoints[0].position) < 0.5f)
        {
            toggle = true;
        }
        else if (Vector2.Distance(transform.position, movementPoints[1].position) < 0.5f)
        {
            toggle = false;
        }

    }

    private void FixedUpdate()
    {
        // Move the platform to each of the platform points
        if (toggle)
        {
            transform.position = Vector2.Lerp(transform.position, movementPoints[1].position, Time.deltaTime * platformSpeed);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, movementPoints[0].position, Time.deltaTime * platformSpeed);
        }
    }
}
