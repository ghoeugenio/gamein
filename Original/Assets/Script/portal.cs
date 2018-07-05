using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

    public bool transporte, destruidos;
    private float espera;

	// Use this for initialization
	void Start () {
        transporte = false;
        destruidos = false;
        espera = 3f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transporte)
        {
            if (destruidos)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<player>().transform.position = transform.position;
                Destroy(gameObject.GetComponent<SpriteRenderer>());
                Destroy(gameObject.GetComponent<Animation>());
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            }
            if(espera > 0)
            {
                espera -= Time.deltaTime;
            }
            else
            {
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
                Destroy(gameObject);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "bloco") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco") || (collision.gameObject.tag == "player2"))
        {
            GameObject.FindGameObjectWithTag("portal").GetComponent<AudioSource>().Play();
            transporte = true;
            destruidos = true;
            Update(); 
        }
    }
}
