using UnityEngine;
using UnityEngine.EventSystems;

public class Movement_Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocità di movimento
    private Rigidbody2D _rigidbody; // Riferimento al Rigidbody2D

    private void Start()
    {
        // Obtain the component Rigidbody2D
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // Asse X (destra/sinistra)
        float moveY = Input.GetAxisRaw("Vertical"); // Asse Y (su/giù)

        // Create a vectro for the movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Movement to th rigidbody
        _rigidbody.linearVelocity = movement * moveSpeed;
    }
}

