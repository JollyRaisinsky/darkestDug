using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healthAmount = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.health += healthAmount;
            debut.text = "Health: " + player.health;
            
            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}
