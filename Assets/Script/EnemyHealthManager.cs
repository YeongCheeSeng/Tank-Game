using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    private string healthBarID = "Health";
    private Health[] _characterHealth;
    private Image[] healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _character = GameObject.FindGameObjectsWithTag("Enemy");

        if (_character == null || _character.Length == 0)
            return;

        _characterHealth = new Health[_character.Length];
        healthBar = new Image[_character.Length];

        for (int i = 0; i < _character.Length; i++)
        {
            _characterHealth[i] = _character[i].GetComponent<Health>();
            healthBar[i] = GetHealthBarID(_character[i]);

            healthBar[i].fillAmount = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _characterHealth.Length; i++)
        {
            if (healthBar[i] != null && _characterHealth[i] != null)
            {
                float currentHealth = _characterHealth[i].currentHealth;
                float maxHealth = _characterHealth[i].maxHealth;
                healthBar[i].fillAmount = currentHealth / maxHealth;
            }
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
