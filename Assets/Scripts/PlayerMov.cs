using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMov : MonoBehaviour
{

    public float Speed; //Variavel de velocidade
    public float Jumpforce; //Variavel de forca do pulo
    public bool isJumping;  //Variavel para saber se ele esta pulando(como pode ver e um valor BOOLEANO, que foi colocado para o player nao ficar pulando infinitamente.)
    private Rigidbody2D rb; //Variavel do Rigibody(uma "extesao" para o player onde vc seta a gravidade e afins)

    private Animator anim;  //Variavel do Animator para rodar as animacoes
    public GameObject heartPrefab;


    public float health;

    public Text lifeText;


    // Start is called before the first frame update
    void Start()
    {
        // O metodo start e chamado ANTES DO PRIMEIRO FRAME(ISSO E IMPORTANTISSIMO SABER NA HORA DE APRESENTAR) por isso aqui dentro a gente tem o rb(rigibody2d) e o anim(de animator)
        // ambos recebem o "GetComponent" com o nome da extesao pois eles precisam ser iniciados antes de iniciar o jogo!

        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        lifeText = GameObject.Find("VidaText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!GameManager.IsGamePaused)
       {
        Move();
        Jump();
        Health();
       } //o metodo Update e chamado A CADA FRAME do jogo, dentro desse metodo a gente chama outros dois METODOS o metodo move e o metodo jump pois sao metodos que precisam ser atualizados a cada frame.
    }

    void Move()
    // metodo move foi criado apenas para a movimentacao e ANIMACAO do personagem, e mais facil e organizado, criar um metodo em vez de adiciona-lo ao metodo update.
    {
        Vector3 movement = new(Input.GetAxis("Horizontal"), 0f, 0f); // essa linha de codigo pega o Vector3(Vetor 3 e o vetor de 3 dimensoes utilizado para x,y e z, ) por mais que seja um jogo 2D utilizamos ele para evitar bugs.
        // esse nome que damos para dizer que o Vector3 se tornou um novo Vector3
        // como andamos em duas dimensoes o Horizontal no lugar do x e para que as teclas a ou d(e setas consequentemente) sejam utilizadas para mover o personagem, os numero 0f tanto em y e x pq se trata de um jogo 2D.
        
        transform.position += Speed * Time.deltaTime * movement; // aqui pegamos a variavel de velocidade e multiplicamos ela com o Time.deltatime(variavel q representa o tempo) e com o movimento para nos movimentarmos no mapa.
        if(Input.GetAxis("Horizontal") > 0f) 
        { 
            anim.SetBool("walk", true);
            transform.eulerAngles = new(0f,0f,0f); //
        }
        if(Input.GetAxis("Horizontal") < 0f) 
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal") == 0f) 
        {
            anim.SetBool("walk", false);
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if(collision.gameObject.CompareTag("Heart"))
        {
            HeartScript heartScript = collision.gameObject.GetComponent<HeartScript>();
            if(heartScript != null)
            {
                Heal(heartScript.healingAmount);
                Destroy(collision.gameObject);
            }
        }
    }

     void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
    void Health()
    {
        if(health < 0) 
        {
            gameObject.SetActive(false);
            Debug.Log("Dead");
            Invoke("ReloadLevel", 1f);
        }
        lifeText.text = "" + health.ToString();
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
    }

}
