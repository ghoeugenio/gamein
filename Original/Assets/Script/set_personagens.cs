using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_personagens : MonoBehaviour {

    public GameObject qua1, tri1, pen1, tra1, oct1;
    public GameObject qua2, tri2, pen2, tra2, oct2;
    private int x, y;

    // Use this for initialization
    void Awake () {
        x = selecao.select1;
        y = selecao.select2;

        if(x == 0)
        {
            qua1.SetActive(true);
        }

        if (x == 1)
        {
            tri1.SetActive(true);
        }

        if (x == 2)
        {
            pen1.SetActive(true);
        }

        if (x == 3)
        {
            tra1.SetActive(true);
        }

        if (x == 4)
        {
            oct1.SetActive(true);
        }

        if (y == 0)
        {
            qua2.SetActive(true);
        }

        if (y == 1)
        {
            tri2.SetActive(true);
        }

        if (y == 2)
        {
            pen2.SetActive(true);
        }

        if (y == 3)
        {
            tra2.SetActive(true);
        }

        if (y == 4)
        {
            oct2.SetActive(true);
        }

    }
	
}
