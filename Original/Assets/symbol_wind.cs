using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbol_wind : MonoBehaviour {

    private SpriteRenderer img_seta;

	// Use this for initialization
	void Start () {
        img_seta = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind < 0f)
        {
            img_seta.flipX = true;
        }

        else
        {
            img_seta.flipX = false;
        }
	}
}
