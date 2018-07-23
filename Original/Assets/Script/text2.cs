using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text2 : MonoBehaviour {

    public Text vidap2, forca2, tempo2, vento2;
    public GameObject gochar2, gopro2, govento2;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        vento2.text = govento2.GetComponent<vento>().printwind.ToString().Substring(0, 3);
        vidap2.text = gochar2.GetComponent<player2>().vida.ToString();

        if (gochar2.GetComponent<player2>().tdj >= 10)
        {
            tempo2.text = "Tempo: " + gochar2.GetComponent<player2>().tdj.ToString().Substring(0, 2);
        }
        else
        {
            tempo2.text = "Tempo: " + gochar2.GetComponent<player2>().tdj.ToString().Substring(0, 1);
        }

        if (gopro2.GetComponent<projetil2>().pro_str >= 10)
        {
            forca2.text = "Força: " + gopro2.GetComponent<projetil2>().pro_str.ToString().Substring(0, 4);
        }
        else
        {
            forca2.text = "Força: " + gopro2.GetComponent<projetil2>().pro_str.ToString().Substring(0, 3);
        }
    }
}
