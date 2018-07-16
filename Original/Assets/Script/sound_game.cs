using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sound_game : MonoBehaviour {

    public static Scene cena;
    public static AudioSource som;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        som = GetComponent<AudioSource>();
        som.Play();
	}
	
	// Update is called once per frame
	void Update () {
        cena = SceneManager.GetActiveScene();
        if (cena.name == "Fase")
        {
            Destroy(gameObject);
        }
        if (cena.name != "menu_inicial")
        {
            som.volume = 0.3f;
        }
    }
}
