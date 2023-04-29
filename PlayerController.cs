using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input from arrow keys or joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        direction = transform.TransformDirection(direction);

        // Move player in direction they are facing
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
