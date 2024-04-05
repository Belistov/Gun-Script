using UnityEngine;

public class healthCode : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
