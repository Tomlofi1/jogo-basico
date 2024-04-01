using UnityEngine;

public class PolicialVida : MonoBehaviour
{
    public int health;
    
    // Start is called before the first frame update
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(CompareTag("Boss"))
        {
            GameManager.PauseGame();
            Destroy(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
