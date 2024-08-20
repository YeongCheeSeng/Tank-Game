using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private GameObject _character;
    private string healthBarID = "PlayerHealth";
    private Health _characterHealth;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _character = GameObject.FindGameObjectWithTag("Player");
        _characterHealth = _character.GetComponent<Health>();
        healthBar = GetHealthBarID(_character);

        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;
            return;
        }
        else
        {
            Debug.LogError("Health bar not found for enemy: " + _character.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar == null || _character == null)
        {
            return;
        }

        if (healthBar != null && _characterHealth != null)
        {
            float currentHealth = _characterHealth.currentHealth;
            float maxHealth = _characterHealth.maxHealth;
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    private Image GetHealthBarID(GameObject _character)
    {
        Image[] images = _character.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            if (image.name == healthBarID)
                return image;
        }

        return null;
    }
}
