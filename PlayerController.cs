using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    public int attackDamage = 10;



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
        click();
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("your mom");
        }
    }

    void click() {
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

    void Attack()
    {
        // Get all colliders within range of the attack
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        // Loop through all colliders and apply damage to enemies
       foreach (Collider enemy in hitColliders)
            {
                if (enemy.CompareTag("enemy"))
                {
                    // Deal damage to the enemy
                    //enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    print("Enemy hit!");
                }
                print("Enemy not hit!");
            }
    }

   
}


