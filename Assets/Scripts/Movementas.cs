using UnityEngine;
using UnityEngine.InputSystem;

public class Movementas : MonoBehaviour
{
    private Vector2 direction;
    public float moveSpeed = 5f;

    void Update()
    {
        // Read horizontal input (A/D, Left/Right arrows, or joystick)
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction = new Vector2(horizontal, 0f);

        // Create a direction vector (x = horizontal, y = 0)
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}

