using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public int healingAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMov playerMov = other.GetComponent<PlayerMov>();
            if(playerMov != null)
            {
                playerMov.Heal(healingAmount);
                Destroy(gameObject);

            }

        }
    }
}
