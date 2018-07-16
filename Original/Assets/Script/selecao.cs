using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selecao : MonoBehaviour {

    public static int select1 = 0, select2 = 0;
    public GameObject qua1, tri1, pen1, tra1, oct1;
    public GameObject qua2, tri2, pen2, tra2, oct2;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        qua1.SetActive(true);
        qua2.SetActive(true);
        tri1.SetActive(false);
        tri2.SetActive(false);
        pen1.SetActive(false);
        pen2.SetActive(false);
        tra1.SetActive(false);
        tra2.SetActive(false);
        oct1.SetActive(false);
        oct2.SetActive(false);
    }

    public void sel1_Quadracima()
    {
        select1 = 0;
        qua1.SetActive(true);
        tri1.SetActive(false);
        pen1.SetActive(false);
        tra1.SetActive(false);
        oct1.SetActive(false);

    }

    public void sel2_Quadracima()
    {
        select2 = 0;
        qua2.SetActive(true);
        tri2.SetActive(false);
        pen2.SetActive(false);
        tra2.SetActive(false);
        oct2.SetActive(false);
    }

    public void sel1_Demetrian()
    {
        select1 = 1;
        qua1.SetActive(false);
        tri1.SetActive(true);
        pen1.SetActive(false);
        tra1.SetActive(false);
        oct1.SetActive(false);
    }

    public void sel2_Demetrian()
    {
        select2 = 1;
        qua2.SetActive(false);
        tri2.SetActive(true);
        pen2.SetActive(false);
        tra2.SetActive(false);
        oct2.SetActive(false);
    }

    public void sel1_Epentono()
    {
        select1 = 2;
        qua1.SetActive(false);
        tri1.SetActive(false);
        pen1.SetActive(true);
        tra1.SetActive(false);
        oct1.SetActive(false);
    }

    public void sel2_Epentono()
    {
        select2 = 2;
        qua2.SetActive(false);
        tri2.SetActive(false);
        pen2.SetActive(true);
        tra2.SetActive(false);
        oct2.SetActive(false);
    }

    public void sel1_Bertrape()
    {
        select1 = 3;
        qua1.SetActive(false);
        tri1.SetActive(false);
        pen1.SetActive(false);
        tra1.SetActive(true);
        oct1.SetActive(false);
    }

    public void sel2_Bertrape()
    {
        select2 = 3;
        qua2.SetActive(false);
        tri2.SetActive(false);
        pen2.SetActive(false);
        tra2.SetActive(true);
        oct2.SetActive(false);
    }

    public void sel1_Octavio()
    {
        select1 = 4;
        qua1.SetActive(false);
        tri1.SetActive(false);
        pen1.SetActive(false);
        tra1.SetActive(false);
        oct1.SetActive(true);
    }

    public void sel2_Octavio()
    {
        select2 = 4;
        qua2.SetActive(false);
        tri2.SetActive(false);
        pen2.SetActive(false);
        tra2.SetActive(false);
        oct2.SetActive(true);
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
