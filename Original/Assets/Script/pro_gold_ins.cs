using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pro_gold_ins : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().prefab_projetil.GetComponent<projetil>().dano = 20;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "player2")
        {
            GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().prefab_projetil.GetComponent<projetil>().dano = 20;
            Destroy(gameObject);
        }
    }
}
