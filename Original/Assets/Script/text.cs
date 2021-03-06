﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {

    public Text vidap1, forca, tempo, vento;
    public GameObject gochar, gopro, govento;

	// Use this for initialization
	void Start () {
        vento.text = govento.GetComponent<vento>().printwind.ToString().Substring(0, 3);
        vidap1.text = gochar.GetComponent<player>().vida.ToString();
        tempo.text = "Tempo: " + gochar.GetComponent<player>().tdj.ToString().Substring(0, 1); ;
        forca.text = gopro.GetComponent<projetil>().pro_str.ToString().Substring(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
        vento.text = govento.GetComponent<vento>().printwind.ToString().Substring(0, 3);
        vidap1.text = gochar.GetComponent<player>().vida.ToString();

        if(gochar.GetComponent<player>().tdj >= 10)
        {
            tempo.text = "Tempo: " + gochar.GetComponent<player>().tdj.ToString().Substring(0, 2);
        }
        else
        {
            tempo.text = "Tempo: " + gochar.GetComponent<player>().tdj.ToString().Substring(0, 1);
        }

        if(gopro.GetComponent<projetil>().pro_str >= 10)
        {
            forca.text = "Força: " + gopro.GetComponent<projetil>().pro_str.ToString().Substring(0, 4);
        }
        else
        {
            forca.text = "Força: " + gopro.GetComponent<projetil>().pro_str.ToString().Substring(0, 3);
        }  
    }
}
