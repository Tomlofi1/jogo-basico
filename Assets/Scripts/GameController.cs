using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalvida;
    public Text vidaText;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }
    public void UpdateScoreText()
    {
        vidaText.text = totalvida.ToString();
    }
}
