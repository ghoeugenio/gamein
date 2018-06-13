using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wi : MonoBehaviour {

    private Text texto;
    private float time;
    private Scene cena;
    private AudioSource som;

    // Use this for initialization
    void Start()
    {
        texto = GetComponent<Text>();
        time = 1f;
        som = GetComponent<AudioSource>();
        cena = SceneManager.GetActiveScene();
        if (cena.name == "wi")
        {
            som.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            texto.enabled = !texto.enabled;
            time = 1f;
        }

        if ((Input.GetKey(KeyCode.KeypadEnter)) || (Input.GetKey("return")))
        {
            SceneManager.LoadScene("menu_inicial");
        }

    }
}
