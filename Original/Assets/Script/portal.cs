using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

    public bool transporte, destruidos, desgrude;
    private bool vez, vezdois, japassou;
    private float espera, esperapouca;

	// Use this for initialization
	void Start () {
        transporte = false;
        destruidos = false;
        desgrude = false;
        espera = 3f;
        esperapouca = 0.5f;
        vez = GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez;
        vezdois = GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois;
        japassou = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transporte)
        {
            if (destruidos && !japassou)
            {
                japassou = true;
                if (vezdois)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<player>().transform.position = transform.position;
                }
                if (vez)
                {
                    GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().transform.position = transform.position;
                }

                Destroy(gameObject.GetComponent<SpriteRenderer>());
                Destroy(gameObject.GetComponent<Animation>());
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                if (vezdois)
                {
                    GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
                }
                if (vez)
                {
                    GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
                }
                
            }
            if(espera > 0)
            {
                espera -= Time.deltaTime;
            }
            else if(vezdois)
            {
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().normaliza();
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().move = true;
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().setmol();
                Destroy(gameObject);
            }
            else
            {
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().normaliza();
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().move = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().setmol();
                Destroy(gameObject);
            }
        }
        esperapouca -= Time.deltaTime;
        if(esperapouca < 0)
        {
            desgrude = true;
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "bloco") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco") )
        {
            GameObject.FindGameObjectWithTag("portal").GetComponent<AudioSource>().Play();
            transporte = true;
            destruidos = true;
            Update(); 
        }

        if (desgrude)
        {
            if((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "player2"))
            {
                GameObject.FindGameObjectWithTag("portal").GetComponent<AudioSource>().Play();
                transporte = true;
                destruidos = true;
                Update();
            }
        }
    }
}
