using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCenarios : MonoBehaviour
{
    public List<GameObject> plataformas = new List<GameObject>();
    public List<Transform> plataformasAtuais = new List<Transform>();
    public int ajuste;

    private Transform player;
    private Transform pontoDaPlataforma;
    private int indicePlataforma;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i =0; i < plataformas.Count; i++)
        {
            Transform plataforma= Instantiate(plataformas[i], new Vector3(0,0,i*10),transform.rotation).transform;
            plataformasAtuais.Add(plataforma);
            ajuste += 10;
        }
        pontoDaPlataforma = plataformasAtuais[indicePlataforma].GetComponent<Plataforma>().pontoFinal;
    }

    void Update()
    {
        float distancia = player.position.z - pontoDaPlataforma.position.z;
        if (distancia >= 4)
        {
            ReSpaw(plataformasAtuais[indicePlataforma].gameObject);
            indicePlataforma++;
            if (indicePlataforma > plataformasAtuais.Count - 1)
            {
                indicePlataforma = 0;
            }
            pontoDaPlataforma = plataformasAtuais[indicePlataforma].GetComponent<Plataforma>().pontoFinal;

        }


    }
    public void ReSpaw(GameObject plataforma)
    {
        plataforma.transform.position = new Vector3(0, 0, ajuste);
        ajuste += 10;
    }
}
