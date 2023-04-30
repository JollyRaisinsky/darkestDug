using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    public float attackRange = 2f;
    public int attackDamage = 50;
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
        //camera 
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        // Get input from arrow keys or joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         // Rotate player based on horizontal input
        transform.Rotate(0f, horizontalInput * rotateSpeed * Time.deltaTime, 0f);

        // Move player forward or backward based on vertical input
        Vector3 direction = transform.forward * verticalInput;
        transform.position += direction * moveSpeed * Time.deltaTime;


        click();
        if (Input.GetKeyDown(KeyCode.F))
        {
           Attack();
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

             string colliderTag = hitCollider.tag;

            // Check if the collider belongs to an enemy
            if (colliderTag == "Enemy")
            {
                // Apply damage to the enemy
                GenralHealth enemy = hitCollider.GetComponent<GenralHealth>();
                enemy.TakeDamage(attackDamage);
            }
            
            
        }

    }
    // Draw a sphere around the player to show the range of the attack
    //It doesn't work I don't know why
    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere around the player to show the range of the attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}


