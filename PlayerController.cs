using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    public int attackDamage = 10;
    public int health = 100;


    public void TakeDamage(int damage)
    {
        health -= damage;
        print("Ouch! Health is now " + health);
       
        if (health <= 0)
        {
            // Die
            print("You died!");
            Destroy(gameObject);
        }

    }

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
       foreach (Collider hitCollider in hitColliders)
        {
            // Get the tag of the hit collider
            string colliderTag = hitCollider.tag;

            // Check if the collider belongs to an enemy
            if (colliderTag == "enemy")
            {
                // Deal damage to the enemy
                //hitCollider.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                print("Enemy hit!");
            }
            else
            {
                print("Object with tag " + colliderTag + " hit!");
            }
        }

    }

   void OnDrawGizmosSelected()
{
    // Draw a wire sphere around the player to show the range of the attack
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, attackRange);

    // Draw a sphere for each enemy within range
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
    foreach (Collider hitCollider in hitColliders)
    {
        // Check if the collider belongs to an enemy
        EnemyController enemy = hitCollider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(enemy.transform.position, 0.5f);
        }
    }
}

}


