using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //This is called whenever the enemy physically touches anything
    private void OnCollisionEnter(Collision collision)
    {
        //Try to get the PlayerHealth component; if it exists, that means we hit the player, and can deal damage
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(5);
        }
    }
}
