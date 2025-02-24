using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 5; 

 
    public void TakeDamage(int damage)
    {
        health -= damage;

        // If health reaches 0, destroy the player

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); 
    }
}
