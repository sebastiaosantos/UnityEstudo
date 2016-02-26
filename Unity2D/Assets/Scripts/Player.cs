using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    private bool estaNoChao;
    public Transform chaoVerificador;
    public Transform spritePlayer;
    private Animator animator;
    public LayerMask piso;

    //Tudo que ocorre quando o personagem e criado
    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    //Tudo que ocorre enquanto o personagem existe
    void Update()
    {
        Movimentacao();
    }

    //Responsavel pela movimentacao do personagem
    void Movimentacao()
    {

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

        //Verifica se esta no chao
        estaNoChao = Physics2D.OverlapCircle(chaoVerificador.position, 0.2f, piso);
        animator.SetBool("chao", estaNoChao);

        //Responsavel pelo pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }
}

