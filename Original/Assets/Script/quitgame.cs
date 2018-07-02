using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitgame : MonoBehaviour {

    private float x = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x -= Time.deltaTime;
        if(x < 0)
        {
            print(x);
            Application.Quit();
        }
	}
}
