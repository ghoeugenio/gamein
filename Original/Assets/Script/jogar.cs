using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogar : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject camperum;
    public GameObject camperdois;
    public bool vez, vezdois, cantum, cantwo;

    // Use this for initialization
    void Start () {
        //player1.GetComponent<player>().enabled = true;
        //camperum.SetActive(true);
        //player2.GetComponent<player>().enabled = false;
        //camperdois.SetActive(false);

        GameObject.FindGameObjectWithTag("Player").GetComponent<player>().enabled = true;
        GameObject.FindGameObjectWithTag("camper").SetActive(true);
        GameObject.FindGameObjectWithTag("jogada").SetActive(true);
        GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().enabled = false;
        GameObject.FindGameObjectWithTag("camper2").SetActive(false);
        GameObject.FindGameObjectWithTag("jogada2").SetActive(false);
        //print(GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_collider);
    }
	
	// Update is called once per frame
	void Update () {

        if (vez)
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().enabled = true;
            camperdois.SetActive(true);
            //GameObject.FindGameObjectWithTag("camper2").SetActive(true);
            player2.SetActive(true);
            //GameObject.FindGameObjectWithTag("jogada2").SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().enabled = false;
            camperum.SetActive(false);
            //GameObject.FindGameObjectWithTag("camper").SetActive(false);
            player1.SetActive(false);
            //GameObject.FindGameObjectWithTag("jogada").SetActive(false);
        }
        
        if (vezdois)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().enabled = true;
            camperum.SetActive(true);
            //GameObject.Find("camper").SetActive(true);
            player1.SetActive(true);
            //GameObject.Find("jogada").SetActive(true);
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().enabled = false;
            camperdois.SetActive(false);
            //GameObject.Find("camper2").SetActive(false);
            player2.SetActive(false);
            //GameObject.Find("jogada2").SetActive(false);
        }
    }
}
