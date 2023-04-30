using UnityEngine;

public class GenralHealth : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 50;
    public float attackCooldown = 1f;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;

    void AttackV2()
    {
        // Attack
        if (!isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            // Play attack animation

           
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
                if (colliderTag == "Player")
                {
                    // Apply damage to the enemy
                    GenralHealth Player = hitCollider.GetComponent<GenralHealth>();
                    Player.TakeDamage(attackDamage);
                }
            }
        }


        // Reset isAttacking flag after attackCooldown time
        if (isAttacking && Time.time - lastAttackTime > attackCooldown)
        {
            isAttacking = false;
        }
    


    }

}