using UnityEngine;

public class GenralHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject prefabToSpawn = null;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            Die();
        }
    }

    void Die()
    {
        // Play death animation or sound
        Destroy(gameObject);
    }
}
