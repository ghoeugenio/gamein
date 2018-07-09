using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vento : MonoBehaviour {

    public float wind, printwind;
    public bool x, y;
    //public GameObject symum, symdois;
    //public bool flum, fldois;

	// Use this for initialization
	void Start () {
        //flum = symum.GetComponent<SpriteRenderer>().flipX;
        //fldois = symdois.GetComponent<SpriteRenderer>().flipX;
        x = true;
        y = false;
        wind = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez && x)
        {
            wind = Random.Range(-3.0f, 3.0f);
            y = true;
            x = false;
        }
        

        if (GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois && y)
        {
            wind = Random.Range(-3.0f, 3.0f);
            x = true;
            y = false;
        }
        if(wind < 0)
        {
            printwind = wind * (-1);
        }
        else
        {
            printwind = wind;
        }
        
    }
}
