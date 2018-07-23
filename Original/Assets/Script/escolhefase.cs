using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escolhefase : MonoBehaviour {

    public AudioSource som;

    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    public void loadfaseum()
    {
        SceneManager.LoadScene("Fase");
        som.Play();
    }

    public void loadfasedois()
    {
        SceneManager.LoadScene("Fase2");
        som.Play();
    }

    public void loadfasetres()
    {
        //SceneManager.LoadScene("Fase3");
        som.Play();
    }

    public void voltar()
    {
        SceneManager.LoadScene("selecaodepersonagem");
    }



}
