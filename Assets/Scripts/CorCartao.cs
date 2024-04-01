using UnityEngine;

public class CorCartao : MonoBehaviour
{
    public Color color1 = Color.yellow;
    public Color color2 = Color.red;
    public float colorChangeInterval;

    private SpriteRenderer spriteRenderer;
    private bool isColor1 = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.Log("SpriteRenderer nao encontrado");
        }
        
        InvokeRepeating("ChangeColor", 1f, colorChangeInterval);
        
    }

    
    void ChangeColor()
    {
        if (isColor1)
        {
            spriteRenderer.color = color2;
        }
        else
        {
            spriteRenderer.color = color1;
        }
        isColor1 = !isColor1;
        
    }
}
