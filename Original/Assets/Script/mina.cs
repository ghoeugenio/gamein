using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mina : MonoBehaviour {

    public GameObject explosao;
    public bool jahitou;

    public void Start()
    {
        jahitou = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        float x, y;
        Quaternion qua;
        Vector2 vec;

        if (((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "player2") || (collision.gameObject.tag == "projetil") || (collision.gameObject.tag == "projetil2")) && !jahitou)
        {
            jahitou = true;
            x = transform.position.x;
            y = transform.position.y;
            qua = transform.rotation;
            vec = new Vector2(x, y - 0.3f);
            Instantiate(explosao, vec, qua);
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
