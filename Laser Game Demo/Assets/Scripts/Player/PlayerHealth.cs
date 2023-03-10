using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthUi;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject gameOverScreen;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            enabled = false;
            gameOverScreen.SetActive(true);
        }
        else
        {
            healthUi.value = currentHealth;
        }
    }
}
