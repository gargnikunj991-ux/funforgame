using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
                movement.y += 1f;

            if (Keyboard.current.sKey.isPressed)
                movement.y -= 1f;

            if (Keyboard.current.aKey.isPressed)
                movement.x -= 1f;

            if (Keyboard.current.dKey.isPressed)
                movement.x += 1f;
        }

        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}