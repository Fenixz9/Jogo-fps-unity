using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float velocidade = 5;
    public float velocidadeCorrida = 9;
    public KeyCode teclaDeCorrida = KeyCode.LeftShift;
    public Animator anim;

    private Rigidbody rb;
    private float velocidadeAtual;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocidadeAtual = velocidade;
    }

    void FixedUpdate()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputZ = Input.GetAxis("Vertical");

        if (inputX != 0 || inputZ != 0)
        {
            transform.Translate(new Vector3(inputX, 0, inputZ) * velocidadeAtual * Time.deltaTime);

            if(Input.GetKey(teclaDeCorrida))
            {
                anim.SetBool("run", true);
                velocidadeAtual = velocidadeCorrida;
            }
            else
            {
                anim.SetBool("run", false);
                velocidadeAtual = velocidade;
            }
        }
        else
        {
            anim.SetBool("run", false);
            velocidadeAtual = velocidade;
        }
    }
}
