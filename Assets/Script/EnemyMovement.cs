using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    private Transform player;
    public Transform[] waypoint;
    private int currentWaypointIndex = 0;
    public bool canChasePlayer = true;

    public GameObject Projectile;
    public GameObject[] FireFeedback;
    public Transform ProjectileSpawnPos;

    private bool _canShoot = true;
    public float ShootCD;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && canChasePlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            //Look at player
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else if (waypoint.Length >= 0)
        {
            transform.position = transform.position = Vector3.MoveTowards(transform.position, waypoint[currentWaypointIndex].position, speed * Time.deltaTime);

            //Look at current waypoint direction
            Vector3 direction = (waypoint[currentWaypointIndex].position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        if (_canShoot == true && canChasePlayer == true)
        {
            StartCoroutine(Shooting());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("waypoint"))
        {            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoint.Length;        
        }
    }

    IEnumerator Shooting()
    {
        _canShoot = false;

        foreach (GameObject feedback in FireFeedback)
        {
            GameObject feedbacks = GameObject.Instantiate(feedback, ProjectileSpawnPos.position, ProjectileSpawnPos.rotation);
            Destroy(feedbacks, 1f);
        }

        GameObject.Instantiate(Projectile, ProjectileSpawnPos.position, ProjectileSpawnPos.rotation);
        yield return new WaitForSeconds(ShootCD);
        _canShoot = true;
    }
}
