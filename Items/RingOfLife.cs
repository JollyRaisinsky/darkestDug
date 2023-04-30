using UnityEngine;

public class RingOfLife : MonoBehaviour
{

    public string Ring  = "RingOfLife";
    public float modification = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.healFactor *= modification;
            player.health *= (int)modification;

            
            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}
