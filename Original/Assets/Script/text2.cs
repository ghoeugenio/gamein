using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text2 : MonoBehaviour {

    public Text vidap2, forca2, angloy2, direcao2, tempo2, vento2;
    public GameObject gochar2, gopro2, govento2;

    // Use this for initialization
    void Start () {
        angloy2.text = "Altura: 2.00";
        forca2.text = "Forca: 1.00";
    }
	
	// Update is called once per frame
	void Update () {
        /*aux = GameObject.FindWithTag("player2").GetComponent<player2>().tdj.ToString();
        aux = aux.Substring(0, 3);
        tempo.text = aux;
        vidap2.text = GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().vida.ToString();
        aux = GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().pro_str.ToString();
        aux = aux.Substring(0, 5);
        forca.text = aux;
        if (GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().pro_direcao)
        {
            direcao.text = "direita";
        }
        else
        {
            direcao.text = "esquerda";
        }
        aux = GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().pro_angle.ToString();
        aux = aux.Substring(0, 5);
        angloy.text = aux;*/
        vento2.text = "Vento:" + govento2.GetComponent<vento>().printwind.ToString().Substring(0,3);
        if (gopro2.GetComponent<projetil2>().pro_direcao)
        {
            direcao2.text = "Mira: direita";
        }
        else
        {
            direcao2.text = "Mira: esquerda";
        }
        vidap2.text = "Vida: " + gochar2.GetComponent<player2>().vida.ToString();
        tempo2.text = "Tempo: " + gochar2.GetComponent<player2>().tdj.ToString().Substring(0, 1);
        forca2.text = "Forca: " + gopro2.GetComponent<projetil2>().pro_str.ToString().Substring(0, 3);
        angloy2.text = "Altura: " + gopro2.GetComponent<projetil2>().pro_angle.ToString().Substring(0, 3);
        
    }
}
