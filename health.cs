using UnityEngine;

public class HealthCode : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the object
    private float currentHealth; // Current health of the object

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    // Method to apply damage to the object
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce current health by the amount of damage
        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below zero, call the Die method
        }
    }

    // Method to handle object's death
    void Die()
    {
        // Implement death behavior here, such as destroying the object or playing death animations
        Destroy(gameObject);
        Debug.Log("Object is Dead")
    }
}
