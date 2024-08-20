using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints to patrol
    public float moveSpeed = 2f;  // Speed of movement
    public float waypointTolerance = 0.1f; // How close the tank needs to be to consider it has reached the waypoint

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private float initialX; // Initial X position to keep constant
    private bool isFlipped = false; // To track the current flip state

    void Start()
    {
        // Save the initial X position of the tank
        initialX = transform.position.x;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        // Get the current waypoint position, keeping X constant
        Vector3 targetPosition = new Vector3(initialX, waypoints[currentWaypointIndex].position.y, 0);

        // Calculate the direction to the target waypoint (in Y-axis only)
        Vector2 direction = new Vector2(0, targetPosition.y - transform.position.y).normalized;

        // Move towards the waypoint
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        // Check if the tank is close enough to the waypoint to consider it reached
        float distanceToWaypoint = Mathf.Abs(transform.position.y - targetPosition.y);
        if (distanceToWaypoint < waypointTolerance)
        {
            // Go to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Flip the Y scale of the tank's Transform to indicate a direction change
            FlipYAxis();
        }
    }

    void FlipYAxis()
    {
        // Toggle the flip state
        isFlipped = !isFlipped;

        // Flip the Y scale
        Vector3 newScale = transform.localScale;
        newScale.y = isFlipped ? -1 : 1;
        transform.localScale = newScale;
    }
}

