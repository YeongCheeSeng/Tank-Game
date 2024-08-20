using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public GameObject DieEffectParticle;
    public GameObject DieAudio;

    public GameObject[] HurtFeedback;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth > 0) 
        {
            foreach (var feedback in HurtFeedback) 
            {
                GameObject feedbacks = GameObject.Instantiate(feedback, transform.position, transform.rotation);
                Destroy(feedbacks, 1f);
            }            
        }

        if (currentHealth <= 0)
        {
            GameObject.Instantiate(DieAudio,transform.position,transform.rotation);
            GameObject.Instantiate(DieEffectParticle,transform.position,transform.rotation);
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
