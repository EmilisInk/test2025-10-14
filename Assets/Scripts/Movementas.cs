using UnityEngine;
using UnityEngine.InputSystem;

public class Movementas : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovePlayer(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log("Input: " + movementInput);
    }

    private void Update()
    {
        rb.velocity = new Vector2(movementInput.x * speed, rb.velocity.y);
    }
}
