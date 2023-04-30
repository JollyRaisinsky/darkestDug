using UnityEngine;

public class HealthObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.health += 10;
            
            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}
