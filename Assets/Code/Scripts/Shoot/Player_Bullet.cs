using System;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    internal void SetVelocity(Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public int damage = 1; // Danno inflitto dal proiettile


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se l'oggetto con cui il proiettile è entrato in contatto è un nemico
        if (other.CompareTag("Enemy"))
        {
            // Infliggi danno al nemico
            other.GetComponent<Enemy_Health>().TakeDamage(damage);

            // Distruggi il proiettile
            Destroy(gameObject);
        }
        else
        {
            // Distruggi il proiettile
            Destroy(gameObject);
        }
    }
}

