using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jogar : MonoBehaviour {

    public bool vez, vezdois, cantum, cantwo;
    public GameObject qua1p, qua1c, qua1j, tri1p, tri1c, tri1j, pen1p, pen1c, pen1j, tra1p, tra1c, tra1j, oct1p, oct1c, oct1j;
    public GameObject qua2p, qua2c, qua2j, tri2p, tri2c, tri2j, pen2p, pen2c, pen2j, tra2p, tra2c, tra2j, oct2p, oct2c, oct2j;
    public GameObject control_bonus, cameraprincipal; //menu_pause;
    private int x, y;
    public int rodadas;
    public Scene cena;

    // Use this for initialization
    void Awake()
    {
        cena = SceneManager.GetActiveScene();
        rodadas = 1;
        x = selecao.select1;
        y = selecao.select2;

        if (x == 0)
        {
            qua1p.GetComponent<player>().enabled = true;
            qua1c.SetActive(true);
            qua1j.SetActive(true);
        }

        if (x == 1)
        {
            tri1p.GetComponent<player>().enabled = true;
            tri1c.SetActive(true);
            tri1j.SetActive(true);
        }

        if (x == 2)
        {
            pen1p.GetComponent<player>().enabled = true;
            pen1c.SetActive(true);
            pen1j.SetActive(true);
        }

        if (x == 3)
        {
            tra1p.GetComponent<player>().enabled = true;
            tra1c.SetActive(true);
            tra1j.SetActive(true);
        }

        if (x == 4)
        {
            oct1p.GetComponent<player>().enabled = true;
            oct1c.SetActive(true);
            oct1j.SetActive(true);
        }

        if (y == 0)
        {
            qua2p.GetComponent<player2>().enabled = false;
            qua2c.SetActive(false);
            qua2j.SetActive(false);
        }

        if (y == 1)
        {
            tri2p.GetComponent<player2>().enabled = false;
            tri2c.SetActive(false);
            tri2j.SetActive(false);
        }

        if (y == 2)
        {
            pen2p.GetComponent<player2>().enabled = false;
            pen2c.SetActive(false);
            pen2j.SetActive(false);
        }

        if (y == 3)
        {
            tra2p.GetComponent<player2>().enabled = false;
            tra2c.SetActive(false);
            tra2j.SetActive(false);
        }

        if (y == 4)
        {
            oct2p.GetComponent<player2>().enabled = false;
            oct2c.SetActive(false);
            oct2j.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<player>().vida <= 0)
        {
            SceneManager.LoadScene("p2win");
        }

        if (GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().vida <= 0)
        {
            SceneManager.LoadScene("p1win");
        }

        if (vez)
        {
           /* if (Input.GetKey(KeyCode.Escape))
            {
                if (menu_pause == true)
                {
                    menu_pause.SetActive(false);
                }
                else
                {
                    menu_pause.SetActive(true);
                }
            }*/

            GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().show_obj = true;
            if (x == 0)
            {
                qua1p.GetComponent<player>().enabled = false;
                qua1c.SetActive(false);
                qua1j.SetActive(false);
            }

            if (x == 1)
            {
                tri1p.GetComponent<player>().enabled = false;
                tri1c.SetActive(false);
                tri1j.SetActive(false);
            }

            if (x == 2)
            {
                pen1p.GetComponent<player>().enabled = false;
                pen1c.SetActive(false);
                pen1j.SetActive(false);
            }

            if (x == 3)
            {
                tra1p.GetComponent<player>().enabled = false;
                tra1c.SetActive(false);
                tra1j.SetActive(false);
            }

            if (x == 4)
            {
                oct1p.GetComponent<player>().enabled = false;
                oct1c.SetActive(false);
                oct1j.SetActive(false);
            }

            if (y == 0)
            {
                qua2p.GetComponent<player2>().enabled = true;
                qua2c.SetActive(true);
                qua2j.SetActive(true);
            }

            if (y == 1)
            {
                tri2p.GetComponent<player2>().enabled = true;
                tri2c.SetActive(true);
                tri2j.SetActive(true);
            }

            if (y == 2)
            {
                pen2p.GetComponent<player2>().enabled = true;
                pen2c.SetActive(true);
                pen2j.SetActive(true);
            }

            if (y == 3)
            {
                tra2p.GetComponent<player2>().enabled = true;
                tra2c.SetActive(true);
                tra2j.SetActive(true);
            }

            if (y == 4)
            {
                oct2p.GetComponent<player2>().enabled = true;
                oct2c.SetActive(true);
                oct2j.SetActive(true);
            }
        }
        
        if (vezdois)
        {
            GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().show_obj = true;
            if (x == 0)
            {
                qua1p.GetComponent<player>().enabled = true;
                qua1c.SetActive(true);
                qua1j.SetActive(true);
            }

            if (x == 1)
            {
                tri1p.GetComponent<player>().enabled = true;
                tri1c.SetActive(true);
                tri1j.SetActive(true);
            }

            if (x == 2)
            {
                pen1p.GetComponent<player>().enabled = true;
                pen1c.SetActive(true);
                pen1j.SetActive(true);
            }

            if (x == 3)
            {
                tra1p.GetComponent<player>().enabled = true;
                tra1c.SetActive(true);
                tra1j.SetActive(true);
            }

            if (x == 4)
            {
                oct1p.GetComponent<player>().enabled = true;
                oct1c.SetActive(true);
                oct1j.SetActive(true);
            }

            if (y == 0)
            {
                qua2p.GetComponent<player2>().enabled = false;
                qua2c.SetActive(false);
                qua2j.SetActive(false);
            }

            if (y == 1)
            {
                tri2p.GetComponent<player2>().enabled = false;
                tri2c.SetActive(false);
                tri2j.SetActive(false);
            }

            if (y == 2)
            {
                pen2p.GetComponent<player2>().enabled = false;
                pen2c.SetActive(false);
                pen2j.SetActive(false);
            }

            if (y == 3)
            {
                tra2p.GetComponent<player2>().enabled = false;
                tra2c.SetActive(false);
                tra2j.SetActive(false);
            }

            if (y == 4)
            {
                oct2p.GetComponent<player2>().enabled = false;
                oct2c.SetActive(false);
                oct2j.SetActive(false);
            }
        }
    }

    public void inc_rodadas()
    {
        rodadas++;
        if(cena.name == "Fase")
        {
            control_bonus.GetComponent<control_bonus>().sortear_posicao = true;
        }
        if (cena.name == "Fase2")
        {
            control_bonus.GetComponent<Control_Bonus_fase2>().sortear_posicao = true;
        }

    }
}
