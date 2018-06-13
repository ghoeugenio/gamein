using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    private Rigidbody2D p_rigidbody;
    private SpriteRenderer p_sprite;
    private AudioSource p_audio;
    public float p_vel;
    private bool p_jump = true, p_chao, p_limite, p_limiteclone;
    public float p_pulo, tdj;
    public int vida = 100;
    //public bool cant;

	// Use this for initialization
	void Start () {
        p_rigidbody = GetComponent<Rigidbody2D>();
        p_sprite = GetComponent<SpriteRenderer>();
        p_audio = gameObject.GetComponent<AudioSource>();
        p_chao = true;
        p_limite = true;
        p_limiteclone = true;

    }

	// Update is called once per frame
	void Update () {

        if(vida <= 0)
        {
            SceneManager.LoadScene("p2win");
        }

        tdj += Time.deltaTime;

        if (tdj >= 10f)
        {
            tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
        }

        if ((Input.GetKey(KeyCode.D)) && p_chao && p_limiteclone)//move pra direita
        {
            p_rigidbody.velocity = new Vector2(p_vel, p_rigidbody.velocity.y);
            p_sprite.flipX = true;
        }

        if ((Input.GetKey(KeyCode.A)) && p_chao && p_limite)//move pra direita
        {
            p_vel *= -1;
            p_rigidbody.velocity = new Vector2(p_vel, p_rigidbody.velocity.y);
            p_vel *= -1;
            p_sprite.flipX = false;
        }

        if((Input.GetKeyDown(KeyCode.W)) && (p_jump))
        {
            p_rigidbody.velocity = new Vector2(0, p_pulo);
            p_audio.Play();
            p_jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            p_jump = true;
        }
        if(collision.gameObject.tag == "limite")
        {
            p_limite = false;
        }
        else
        {
            p_limite = true;
        }

        if (collision.gameObject.tag == "limiteclone")
        {
            p_limiteclone = false;
        }
        else
        {
            p_limiteclone = true;
        }

        if(collision.gameObject.tag == "bloco")
        {
            p_jump = true;
        }

    }

    public void acertou(int total)
    {
        vida = vida - total;
    }
}
