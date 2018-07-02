using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour
{


    private bool destroi;
    private float esperar;

    // Use this for initialization
    void Start()
    {
        destroi = false;
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
        if (collision.gameObject.tag == "chao")
        {
            destroi = true;
            Update();
        }

        if(collision.gameObject.tag == "chao")
        {

        }
       
    }
}

