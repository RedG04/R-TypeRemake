using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Component : MonoBehaviour
{
    [SerializeField] private EntityType type;
    [SerializeField] private Vector2[] deathDirections;

    public Action OnDeath;

    public void Die(Vector2 direction)
    {
        foreach (var _direction in deathDirections)
        {
            if (_direction == direction)
            {
                // death animation and destroy

                OnDeath?.Invoke();

                //gameObject.SetActive(false);

                Debug.Log(gameObject.name + " has died!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death_Component collisionDeathComponent = collision.gameObject.GetComponent<Death_Component>();

        if (collisionDeathComponent && collisionDeathComponent.type != type)
        {
            collisionDeathComponent.Die(collision.contacts[0].normal);
        }
    }
}

public enum EntityType
{
    Player,
    Enemy
}
