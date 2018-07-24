using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    private Rigidbody2D p_rigidbody;
    private SpriteRenderer p_sprite;
    private AudioSource p_audio;
    public GameObject setaum, setadois, simbvento, moldura, cam;
    public float p_vel;
    private bool p_jump = true, p_chao, p_limite, p_limiteclone;
    public float p_pulo, tdj;
    public int vida = 100, limite_vida = 100, defesa;
    public bool correcao, move;
    private int x;

	// Use this for initialization
	void Start () {
        defesa = 0;
        move = true;
        p_rigidbody = GetComponent<Rigidbody2D>();
        p_sprite = GetComponent<SpriteRenderer>();
        p_audio = gameObject.GetComponent<AudioSource>();
        p_chao = true;
        p_limite = true;
        p_limiteclone = true;
        correcao = true;
        p_vel = 1f;
        p_pulo = 4.5f;
        x = selecao.select1;
    }

	// Update is called once per frame
	void Update () {
        
        if(vida > limite_vida)
        {
            vida = limite_vida;
        }

        tdj += Time.deltaTime;

        if (tdj >= 20f)
        {
            tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().normaliza();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().setmol();
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().move = true;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<player>().move = false;
        }
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !GameObject.FindGameObjectWithTag("jogada").GetComponent<projetil>().pro_v)
            {
                cam.SetActive(true);
                setaum.GetComponent<SpriteRenderer>().enabled = false;
                setadois.GetComponent<SpriteRenderer>().enabled = false;
                simbvento.GetComponent<SpriteRenderer>().enabled = false;
                simbvento.GetComponent<Animator>().enabled = false;
                moldura.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                cam.SetActive(false);
                setaum.GetComponent<SpriteRenderer>().enabled = true;
                setadois.GetComponent<SpriteRenderer>().enabled = true;
                simbvento.GetComponent<SpriteRenderer>().enabled = true;
                simbvento.GetComponent<Animator>().enabled = true;
                moldura.SetActive(true);
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

            if ((Input.GetKeyDown(KeyCode.W)) && (p_jump))
            {
                p_rigidbody.velocity = new Vector2(0, p_pulo);
                p_audio.Play();
                p_jump = false;
            }
        }

        else
        {
            moldura.SetActive(false);
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
        vida = vida - total + defesa;
    }

    public void normaliza()
    {
        p_vel = 1.5f;
        p_pulo = 4.5f;
    }

    public void setmol()
    {
        moldura.SetActive(true);
    }

    public void especial()
    {
        if (x == 0)
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().defesa = GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().defesa - 5;
        }

        if (x == 1)
        {
            defesa = defesa + 5;
        }

        if (x == 2)
        {
            vida = vida + 15;
        }

        if (x == 3)
        {
            limite_vida = limite_vida + 50;
            defesa = defesa + 1;
        }

        if (x == 4)
        {
            vida = vida + 5;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().defesa = GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().defesa - 2;
        }
    }
}
