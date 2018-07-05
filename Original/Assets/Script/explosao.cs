﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour
{


    private bool destroi, hit1, hit2;
    private float esperar;

    // Use this for initialization
    void Start()
    {
        destroi = false;
        hit1 = true;
        hit2 = true;
        esperar = 2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (destroi)
        {
            esperar -= Time.deltaTime;
            if(esperar < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hit1)
        {
            hit1 = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().acertou(8);
        }

        if (collision.gameObject.tag == "player2" && hit2)
        {
            hit2 = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player>().acertou(8);
        }

        destroi = true;
        Update();
    }
}
