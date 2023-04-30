using UnityEngine;

public class RingOfTurning : MonoBehaviour
{

    public string Ring = "RingOfTurning";
    public float modification = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Get the PlayerController component from the player
            PlayerController player = other.GetComponent<PlayerController>();

            // Change the values of the variables in the PlayerController script
            player.turnSpeed *= modification;
            
            // Destroy the battle axe object
            Destroy(gameObject);
        }
    }
}

