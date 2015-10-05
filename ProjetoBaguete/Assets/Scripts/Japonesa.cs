using UnityEngine;
using System.Collections;

public class Japonesa : MonoBehaviour
{

    public float velocidade; //velocidade do personagem - mudar na unity
    public float fpulo; //Força do pulo - mudar na unity
    private bool pisando; // está pisando no chao? Y ou N
    public Transform IsOnGround;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }

    void FixedUpdate()
    {
     
    }
    void Movimentacao() //andar, pular e correr
    {

        pisando = Physics2D.Linecast(transform.position, IsOnGround.position, 1 << LayerMask.NameToLayer("Floor")); //verifica se está no chao pra nao pular infinito

        if (Input.GetKeyDown(KeyCode.LeftShift))//correr
        {
            velocidade = velocidade + 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidade = velocidade - 10;
        }

        if (Input.GetAxisRaw("Horizontal") > 0) //andar pra direita

        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0) //rotaciona o vetor a 180° - andar pra esquerda
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }


        if (Input.GetButtonDown("Jump") && pisando) //pular - barra de espaço
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * fpulo);

        }


    }
}