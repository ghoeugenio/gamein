using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public float espera;
    public int select;

    void Start()
    {
        select = -1;
        espera = 0.3f;
    }

    void Update()
    {
        if (select == 0)
        {
            select = 0;
            espera -= Time.deltaTime;
            if(espera < 0)
            {
                SceneManager.LoadScene("selecaodepersonagem");
            }

        }

        if(select == 3)
        {
            select = 3;
            espera -= Time.deltaTime;
            if (espera < 0)
            {
                Application.Quit();
            }

        }
    }

    public void Classic()
    {
        select = 0;
    }

    public void Arcade()
    {
        //SceneManager.LoadScene("");
    }

    public void Configuracoes()
    {
        //SceneManager.LoadScene("");
    }

    public void QuitGame()
    {
        select = 3;
    }
}
