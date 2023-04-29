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
        attack();
    }

    void attack() {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object with a tag
            if (Physics.Raycast(ray, out hit) && hit.collider.tag != null)
            {
                // Print the tag of the object that was clicked
                Debug.Log("Clicked on object with tag: " + hit.collider.tag);
            }
        }
    }

}


