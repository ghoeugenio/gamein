using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadClassic : MonoBehaviour {

	public void Classic()
    {
        SceneManager.LoadScene("Fase");
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
        print("quit");
        Application.Quit();
    }
}
