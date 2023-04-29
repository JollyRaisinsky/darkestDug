using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);

        // Move player to new position
        transform.position = newPosition;
    }
}
