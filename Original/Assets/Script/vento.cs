﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vento : MonoBehaviour {

    public float wind, printwind;
    public bool x, y;

	// Use this for initialization
	void Start () {
        x = true;
        y = false;
        wind = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez && x)
        {
            wind = Random.Range(-2.0f, 2.0f);
            y = true;
            x = false;

        }
        

        if (GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois && y)
        {
            wind = Random.Range(-2.0f, 2.0f);
            x = true;
            y = false;
        }
        printwind = wind;

    }
}
