using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour
{


    private bool hit1, hit2, vez, vezdois;
    private float esperar;
    public int dano;

    // Use this for initialization
    void Start()
    {
        dano = 8;
        hit1 = true;
        hit2 = true;
        esperar = 2f;
        vez = GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez;
        vezdois = GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois;
        print("vez:" + vez);
        print("vezdois:" + vezdois);
    }

    // Update is called once per frame
    void Update()
    {
        if (vezdois)
        {
            esperar -= Time.deltaTime;
            if (esperar < 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
                Destroy(GameObject.FindGameObjectWithTag("projetil"));            //destroi o projetil
                Destroy(gameObject);
            }
        }
        if (vez)
        {
            esperar -= Time.deltaTime;
            if (esperar < 0)
            {
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
                Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hit1)
        {
            hit1 = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().acertou(8);
        }

        if (collision.gameObject.tag == "player2" && hit2)
        {
            hit2 = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().acertou(8);
        }
    }
}

