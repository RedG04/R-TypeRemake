using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health = 3; // Salute del nemico
    public delegate void DeathHandler();
    public event DeathHandler OnDeath; // Evento che segnala la morte del nemico

    // Questo metodo viene chiamato per infliggere danno al nemico
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Se la salute arriva a 0 o meno, distruggi il nemico
        if (health <= 0)
        {
            Die();
            OnDeath?.Invoke();
        }
    }

    // Metodo per distruggere il nemico (puoi aggiungere effetti o animazioni prima di distruggerlo)
    private void Die()
    {
        Destroy(gameObject); // Distruggi il nemico
    }
}