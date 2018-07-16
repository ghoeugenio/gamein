using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_bonus : MonoBehaviour {

    public GameObject jogar, vida, bombagold, faster, barril;
    private GameObject obj_a_instanciar;
    private int posicao, instancia;
    public bool sortear_posicao;
    private Vector2 lugar;

	// Use this for initialization
	void Start () {
        posicao = -1;
        instancia = -1;
        sortear_posicao = true;
	}
	
	// Update is called once per frame
	void Update () {

        if((jogar.GetComponent<jogar>().rodadas % 2) == 0 && sortear_posicao)
        {
            sortear_posicao = false;
            posicao = Random.Range(0, 9);
            instancia = Random.Range(0, 4);
            print(instancia);
            if(instancia == 0)
            {
                obj_a_instanciar = vida;
            }
            if(instancia == 1)
            {
                obj_a_instanciar = bombagold;
            }
            if (instancia == 2)
            {
                obj_a_instanciar = faster;
            }
            if(instancia == 3)
            {
                obj_a_instanciar = barril;
            }
        }

        if (posicao == 0)
        {
            posicao = -1;
            lugar = new Vector2(15.4f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 1)
        {
            posicao = -1;
            lugar = new Vector2(11, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 2)
        {
            posicao = -1;
            lugar = new Vector2(7.4f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 3)
        {
            posicao = -1;
            lugar = new Vector2(4, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 4)
        {
            posicao = -1;
            lugar = new Vector2(0, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 5)
        {
            posicao = -1;
            lugar = new Vector2(-4.8f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 6)
        {
            posicao = -1;
            lugar = new Vector2(-7.4f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 7)
        {
            posicao = -1;
            lugar = new Vector2(-11.8f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }

        if (posicao == 8)
        {
            posicao = -1;
            lugar = new Vector2(-15.95f, 30);
            Instantiate(obj_a_instanciar, lugar, transform.rotation);
        }
    }
}
