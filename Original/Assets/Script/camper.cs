using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setter()
    {
        gameObject.SetActive(true);
    }

    public void unsetter()
    {
        gameObject.SetActive(false);
    }
}
