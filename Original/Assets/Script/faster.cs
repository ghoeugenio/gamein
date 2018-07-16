using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faster : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().p_pulo = 6f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().p_vel = 2f;
        }

        if (collision.gameObject.tag == "player2")
        {
            GameObject.FindGameObjectWithTag("player").GetComponent<player2>().p_pulo = 6f;
            GameObject.FindGameObjectWithTag("player").GetComponent<player2>().p_vel = 2f;
        }
    }

}
