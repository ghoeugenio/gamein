using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao_barril : MonoBehaviour {

    public GameObject text;
    private bool hit1, hit2;
    private float esperar;

    // Use this for initialization
    void Start ()
    {
        esperar = 2f;
        hit1 = true;
        hit2 = true;
    }
	
	// Update is called once per frame
	void Update ()
    {       
        esperar -= Time.deltaTime;
        if (esperar < 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hit1)
        {
            hit1 = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().acertou(30);
            text.SetActive(true);
        }

        if (collision.gameObject.tag == "player2" && hit2)
        {
            hit2 = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().acertou(30);
            text.SetActive(true);
        }
    }
}
