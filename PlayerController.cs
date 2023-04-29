using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        // Get input from arrow keys
        
        float horizontalInput = Input.GetAxisRaw("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        // Calculate new position
        float angle = verticalInput * turnSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);

        // Move player to new position
        transform.position = newPosition;
        transform.Rotate(0f, angle, 0f);

    }
}
