using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "bloco") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco") || (collision.gameObject.tag == "player2"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
