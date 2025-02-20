using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 5; // Salute del nemico

    // Questo metodo viene chiamato per infliggere danno al nemico
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Se la salute arriva a 0 o meno, distruggi il nemico
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
