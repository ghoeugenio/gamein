using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selecao : MonoBehaviour {

    public static int select1 = 0, select2 = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void sel1_Quadracima()
    {
        select1 = 0;
    }

    public void sel2_Quadracima()
    {
        select2 = 0;
    }

    public void sel1_Demetrian()
    {
        select1 = 1;
    }

    public void sel2_Demetrian()
    {
        select2 = 1;
    }

    public void sel1_Epentono()
    {
        select1 = 2;
    }

    public void sel2_Epentono()
    {
        select2 = 2;
    }

    public void sel1_Bertrape()
    {
        select1 = 3;
    }

    public void sel2_Bertrape()
    {
        select2 = 3;
    }

    public void sel1_Octavio()
    {
        select1 = 4;
    }

    public void sel2_Octavio()
    {
        select2 = 4;
    }

    public void comecar()
    {
        SceneManager.LoadScene("Fase");
    }

    public void voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
