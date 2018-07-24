using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour {

    public GameObject menu;
	    
    public void sair()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void continuar()
    {
        menu.SetActive(false);
    }

}
