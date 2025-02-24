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

    public int damage = 1;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Proiettile ha colpito il player");
            other.GetComponent<Player_Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
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
