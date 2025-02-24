using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health = 3;
    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    // This method is called to inflict damage to the enemy
    public void TakeDamage(int damage)
    {
        health -= damage;

        // If health reaches 0, destroy the enemy
        if (health <= 0)
        {
            Die();
            OnDeath?.Invoke();
        }
    }

 
    private void Die()
    {
        Destroy(gameObject); // Destroy the enemy
    }
}