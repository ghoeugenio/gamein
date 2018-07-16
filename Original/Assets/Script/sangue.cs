using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sangue : MonoBehaviour {

    public bool tocou;

    private void Start()
    {
        tocou = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player" && tocou)
        {
            tocou = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().vida += 20;
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "player2" && tocou)
        {
            tocou = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().vida += 20;
            Destroy(gameObject);
        }
    }
}
