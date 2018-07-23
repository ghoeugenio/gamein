using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moldura : MonoBehaviour {

    public GameObject projetil, portal, merda;
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois)
        {
            if (GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().presss)
            {
                projetil.SetActive(false);
                portal.SetActive(true);
            }

            else
            {
                portal.SetActive(false);
                projetil.SetActive(true);
            }

            if (Input.GetKey(KeyCode.C))
            {
                merda.GetComponent<Animator>().enabled = true;
            }

            else
            {
                merda.GetComponent<Animator>().enabled = false;
            }
        }

        if (GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez)
        {
            if (GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().pressk)
            {
                projetil.SetActive(false);
                portal.SetActive(true);
            }

            else
            {
                portal.SetActive(false);
                projetil.SetActive(true);
            }

            if (Input.GetKey(KeyCode.N))
            {
                merda.GetComponent<Animator>().enabled = true;
            }

            else
            {
                merda.GetComponent<Animator>().enabled = false;
            }
        }

    }
}
