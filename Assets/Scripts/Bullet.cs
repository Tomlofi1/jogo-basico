using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int damage = 5;
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        PolicialVida enemy = hitInfo.GetComponent<PolicialVida>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);   
             
    }

}
