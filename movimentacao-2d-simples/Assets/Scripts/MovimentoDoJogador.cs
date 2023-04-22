using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    [Header("Referências Gerais")]
    private Rigidbody2D oRigidbody2D;

    [Header("Movimento Horizontal")]
    [SerializeField] private float velocidadeHorizontal;
    private float inputHorizontal;
    private bool indoParaDireita;

    private void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        indoParaDireita = true;
    }

    // Update is called once per frame
    void Update()
    {
        ReceberInputs();
        VerificarDirecaoDoMovimento();
        EspelharNaHorizontal();
    }

    private void FixedUpdate()
    {
        AplicarMovimento();
    }

    private void ReceberInputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void VerificarDirecaoDoMovimento()
    {
        if (inputHorizontal > 0)
        {
            indoParaDireita = true;
        }
        else if (inputHorizontal < 0)
        {
            indoParaDireita = false;
        }
    }

    private void EspelharNaHorizontal()
    {
        if (indoParaDireita)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void AplicarMovimento()
    {
        oRigidbody2D.velocity = new Vector2(inputHorizontal * velocidadeHorizontal, oRigidbody2D.velocity.y);
    }
}
