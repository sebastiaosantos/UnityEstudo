using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    private bool estaNoChao;
    public Transform chaoVerificador;
    public Transform spritePlayer;
    private Animator animator;
    public LayerMask piso;

    // ataque
    public GameObject ataqueEspecial;
    public float duracaoAtaque;
    private float contagemAtaque;


    //Tudo que ocorre quando o personagem e criado
    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();

      

    }

    //Tudo que ocorre enquanto o personagem existe
    void Update()
    {
        Movimentacao();

        Ataque();


    }

   
    //Responsavel pela movimentacao do personagem
    void Movimentacao()
    {


        //Verifica se esta no chao
         estaNoChao = Physics2D.OverlapCircle(chaoVerificador.position, 0.2f, piso);
       // estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);

        //Seta no paramentro movimento, um valor 0 ou maior que 0. Ira ativar a condicao para mudar de animacao
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        //Anda para a direita
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        //Anda para a esquerda
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

      

        //Responsavel pelo pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }

    // responsavel pelo ataque
    void Ataque()
    {

        // quando eu clico com o botão ele mostra a animação
        if (Input.GetButtonDown("Fire1"))
        {
            ataqueEspecial.SetActive(true);
            contagemAtaque = 0f;
            var player = GetComponent<Vida>();
            player.Damage(20f);
        }

        // quando eu preciono o botão ele verifica se a contagem de tempo é maior ou igual a duração do ataque se sim ele desativa a animação
        if (Input.GetButton("Fire1"))
        {
            contagemAtaque += Time.deltaTime;
            if (contagemAtaque >= duracaoAtaque)
            {
                ataqueEspecial.SetActive(false);
            }
        }
        // quando soltar o botão ele desativa a animação
        if (Input.GetButtonUp("Fire1"))
        {
            ataqueEspecial.SetActive(false);
        }
    }
}

