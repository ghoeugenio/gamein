using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pro_gold_ins : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().prefab_projetil.GetComponent<projetil>().dano = GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().prefab_projetil.GetComponent<projetil>().dano + 10;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "player2")
        {
            GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().prefab_projetil.GetComponent<projetil2>().dano = GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().prefab_projetil.GetComponent<projetil2>().dano + 10;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "barril" || collision.gameObject.tag == "instanciado")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "chao" || collision.gameObject.tag == "bloco")
        {
            gameObject.tag = "instanciado";
        }

    }
}
