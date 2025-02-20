using System;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float lifeTime = 6f;
    private float _currentLifeTime = 0;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetVelocity(Vector2 direction)
    {
        _direction = new Vector2(direction.x, 0);

        _spriteRenderer.flipY = direction.x > 0;
    }

    public int damage = 1; // Danno inflitto dal proiettile


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            other.GetComponent<Player_Health>().TakeDamage(damage);

            // Distruggi il proiettile
            Destroy(gameObject);
        }
        else
        {
            // Distruggi il proiettile
            Destroy(gameObject);
        }
    }
    private void FixedUpdate() => _rigidbody.linearVelocity = _direction * speed;

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

}
