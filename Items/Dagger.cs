using UnityEngine;

public class Dagger : MonoBehaviour
{
    

    public string weapon = "dagger";
    public float newAttackRange = 1.25f;
    public int newAttackDamage = 25;
    public float newAttackCooldown = .5f;
    public float moveSpeed = 7f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player   
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.attackRange = newAttackRange;
            player.attackDamage = newAttackDamage;
            player.attackCooldown = newAttackCooldown;
            player.moveSpeed = moveSpeed;
            player.weapon = weapon;

            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}
