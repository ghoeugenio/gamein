using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {

    public Text vidap1, forca, angloy, direcao, tempo, vento;
    public GameObject gochar, gopro, govento;

	// Use this for initialization
	void Start () {
        angloy.text = "Altura: 2.00";
        forca.text = "Forca: 1.00";
    }
	
	// Update is called once per frame
	void Update () {
        /*aux = GameObject.FindWithTag("Player").GetComponent<player>().tdj.ToString();
        aux = aux.Substring(0, 3);
        tempo.text = aux;
        vidap1.text = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().vida.ToString();
        aux2 = GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_str.ToString();
        aux2 = aux2.Substring(0, 5);
        forca.text = aux;
        if (GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_direcao)
        {
            direcao.text = "direita";
        }
        else
        {
            direcao.text = "esquerda";
        }
        aux = GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_angle.ToString();
        aux = aux.Substring(0, 5);
        angloy.text = aux;*/
        vento.text = "Vento: " + govento.GetComponent<vento>().printwind.ToString().Substring(0, 3);
        if ((gopro.GetComponent<projetil>().pro_direcao))
        {
            //print(GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_direcao);
            direcao.text = ("Direção: direita");
        }
        else
        {
            direcao.text = ("Direção: esquerda");
        }
        vidap1.text = "Vida: " + gochar.GetComponent<player>().vida.ToString();
        tempo.text = "Tempo: " + gochar.GetComponent<player>().tdj.ToString();
        forca.text = "Forca: " + gopro.GetComponent<projetil>().pro_str.ToString().Substring(0,4);
        angloy.text = "Altura: " + gopro.GetComponent<projetil>().pro_angle.ToString().Substring(0, 4);
        
        
        
    }
}
