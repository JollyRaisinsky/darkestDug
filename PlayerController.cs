using UnityEngine;

public class PlayerController : MonoBehaviour
{

    AudioSource basic_swing;

    public string weapon = "sword";
    public float moveSpeed = 5f;
    public float turnSpeed = 30f;

    public float attackRange = 2f;
    public int attackDamage = 50;
    public float attackCooldown = 2f;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;
    
    public int health = 100;

    public GameObject glowstick = null;
    
   

    void Start()
    {
        basic_swing = GetComponent<AudioSource>();
    }


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
        transform.Rotate(0f, horizontalInput * turnSpeed * Time.deltaTime, 0f);

        // Move player forward or backward based on vertical input
        Vector3 direction = transform.forward * verticalInput;
        transform.position += direction * moveSpeed * Time.deltaTime;



        AttackV2();
        click();
        drop();
    }

    void click() {
        if (Input.GetMouseButtonDown(0))
        {
            print(weapon)
        }
        
        
    }
    void drop()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(glowstick, transform.position, transform.rotation);
        }
    }
    // Attack cooldown
    void AttackV2()
    {
        // Attack
        if (!isAttacking && Time.time - lastAttackTime > attackCooldown && Input.GetKeyDown(KeyCode.F))
        {
            // Play attack animation

            // Play attack sound
            basic_swing.Play();
            // Set isAttacking flag to true and save the time of the attack
            isAttacking = true;
            lastAttackTime = Time.time;

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


        // Reset isAttacking flag after attackCooldown time
        if (isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            isAttacking = false;
        }
    


    }

    // Not relvent anymore
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
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


