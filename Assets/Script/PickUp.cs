using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int healAmount;
    private Health health;
    public GameObject[] healFeedback;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && health.currentHealth < health.maxHealth)
        {
            health.Heal(healAmount);

            foreach (var feedbacks in healFeedback) 
            {
                GameObject feedback = GameObject.Instantiate(feedbacks);
                Destroy(feedback,1);
            }

            Destroy(this.gameObject);
        }
    }
}
