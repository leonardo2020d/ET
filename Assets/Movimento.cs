using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public CharacterController playerController;
    public float tempo;

    public bool estanaEsquerda;
    public bool estanoCentro;

    void Start()
    {
        playerController.GetComponent<CharacterController>();
   
    }

    void Update()
    {

        playerController.Move(Vector3.forward * Time.deltaTime * 8);
        MovimentoLateral();
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
