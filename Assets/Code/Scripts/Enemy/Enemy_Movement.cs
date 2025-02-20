using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Unity.Collections.AllocatorManager;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask rayMask;
    [SerializeField] private float rayDistance = 5f;

    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.up;

    private Vector3 OffsetPosition => new(transform.position.x + ((_collider.size.x * 0) + 0) * _direction.x, transform.position.y + 0, 0);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Physics2D.Raycast(OffsetPosition, _direction, rayDistance, rayMask))
        {
            _direction = _direction == Vector2.down ? Vector2.up : Vector2.down;
        }

    }

    private void FixedUpdate() => _rigidbody.linearVelocity = _direction * speed;

    private void OnDrawGizmos()
    {
        if (!_collider) _collider = GetComponent<BoxCollider2D>();

        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(OffsetPosition, _direction * rayDistance);
    }
}
