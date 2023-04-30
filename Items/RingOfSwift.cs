using UnityEngine;

public class RingOfSwift : MonoBehaviour
{

    public string weapon = "RingOfSwift";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.attackCooldown *= .80f;
            
            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}
