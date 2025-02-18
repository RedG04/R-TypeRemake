using UnityEngine;
using UnityEngine.EventSystems;

public class Movement_Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    private Rigidbody2D _rigidbody;
    public Shooting muzzle;

    private void Start()
    {
        // Obtain the component Rigidbody2D
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            muzzle.Fire();
        }

        float moveX = Input.GetAxisRaw("Horizontal"); // X (right/left)
        float moveY = Input.GetAxisRaw("Vertical"); // Y (up/down)

        // Create a vector for the movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Movement to th rigidbody
        _rigidbody.linearVelocity = movement * moveSpeed;
    }
}

