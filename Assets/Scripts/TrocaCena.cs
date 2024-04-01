
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
  
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene("Level2");
        }       
    }
}
