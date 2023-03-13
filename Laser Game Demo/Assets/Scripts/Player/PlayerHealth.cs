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

    //public because we want to be able to call this from the EnemyAttack script
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            this.enabled = false; //Disable the script, so we can't keep taking damage after we die
            gameOverScreen.SetActive(true); //Show the game over screen
        }
        else
        {
            healthUi.value = currentHealth;
        }
    }
}
