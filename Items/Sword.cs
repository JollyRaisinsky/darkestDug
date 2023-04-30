using UnityEngine;

public class Sword : MonoBehaviour
{

    public string weapon = "sword";
    public float newAttackRange = 5f;
    public int newAttackDamage = 50;
    public float newAttackCooldown = 2f;
    public float moveSpeed = 5f;

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
