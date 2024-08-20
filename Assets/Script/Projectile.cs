using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public int ProjectileDamage;
    public float ProjectileLifeTime;

    public LayerMask TargetLayerMask;

    private Rigidbody2D rb;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) return;

        rb.AddRelativeForce(new Vector2(0f, ProjectileSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < ProjectileLifeTime)
        {
            timer += Time.deltaTime;
            return;
        }

        Die();
        timer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("Enemy hit");
                col.GetComponent<Health>().TakeDamage(ProjectileDamage);
                Die();                
            }

            if (col.tag == "Player")
            {
                Debug.Log("Player hit");
                col.GetComponent<Health>().TakeDamage(ProjectileDamage);
                Die();
            }

            if (col.tag == "Obstacle")
            {
                Debug.Log("Obstacle hit");
                Die();
            }

            Debug.Log("Hit: " + col.name);
        }
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }
}
