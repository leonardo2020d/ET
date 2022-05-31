using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public CharacterController playerController;
    public float tempo;

    public bool estanaEsquerda;
    public bool estanoCentro;

    public float forcaPulo;
    public  float velocidadePulo;
    public float gravidade;
    public float velocidade;
    Vector3 direcao;

    void Start()
    {
        playerController.GetComponent<CharacterController>();
   
    }

    void Update()
    {
        direcao = Vector3.forward * velocidade;
        MovimentoLateral();
        if (playerController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadePulo = forcaPulo;
            }
        }
        else
        {
            velocidadePulo -= gravidade;
        }
        direcao.y = velocidadePulo;
        playerController.Move(direcao * Time.deltaTime);




    }
    void MovimentoLateral()
    {
      
       
        if (Input.GetKeyDown(KeyCode.A) && estanaEsquerda==false && estanoCentro == false)
        {
            playerController.Move(Vector3.left*tempo);
            estanoCentro = true;
            
        }
        else if(Input.GetKeyDown(KeyCode.A) && estanaEsquerda==false && estanoCentro == true)
        {
            playerController.Move(Vector3.left * tempo);
            estanoCentro = false;
            estanaEsquerda = true;
        }
        if (Input.GetKeyDown(KeyCode.D)  && estanaEsquerda == true)
        {
            playerController.Move(Vector3.right * tempo);
            estanaEsquerda = false;
            estanoCentro = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && estanaEsquerda == false && estanoCentro == true)
        {
            playerController.Move(Vector3.right * tempo);
            estanoCentro = false;
        }
       
    }
 

}
