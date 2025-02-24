using System;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    internal void SetVelocity(Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public int damage = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the projectile came into contact with is an enemy
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

