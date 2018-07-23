using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour {

    private Rigidbody2D p_rigidbody;
    private SpriteRenderer p_sprite;
    private AudioSource p_audio;
    public GameObject setaum, setadois, simbvento, moldura, cam;
    public float p_vel;
    private bool p_jump = true, p_chao, p_limite, p_limiteclone;
    public float p_pulo, tdj;
    public int vida = 100, limite_vida = 100, defesa;
    public bool move;
    private int y;

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
        tdj = 0;
        p_vel = 1f;
        p_pulo = 4.5f;
        y = selecao.select2;
    }
	
	// Update is called once per frame
	void Update () {
        if (vida > limite_vida)
        {
            vida = limite_vida;
        }

        if (vida <= 0)
        {
            SceneManager.LoadScene("p1win");
        }

        tdj += Time.deltaTime;

        if (tdj >= 20f)
        {
            tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().normaliza();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().setmol();
            //GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().move = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().move = true;

        }
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().pro_v)
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

            if ((Input.GetKey(KeyCode.L)) && p_chao && p_limiteclone)//move pra direita
            {
                p_rigidbody.velocity = new Vector2(p_vel, p_rigidbody.velocity.y);
                p_sprite.flipX = true;
            }

            if ((Input.GetKey(KeyCode.J)) && p_chao && p_limite)//move pra direita
            {
                p_vel *= -1;
                p_rigidbody.velocity = new Vector2(p_vel, p_rigidbody.velocity.y);
                p_vel *= -1;
                p_sprite.flipX = false;
            }

            if ((Input.GetKeyDown(KeyCode.I)) && (p_jump))
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
        if (collision.gameObject.tag == "limite")
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

        if (collision.gameObject.tag == "bloco")
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
        if (y == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().defesa = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().defesa - 5;
        }

        if (y == 1)
        {
            defesa = 5;
        }

        if (y == 2)
        {
            vida = vida + 15;
        }

        if (y == 3)
        {
            limite_vida = 150;
            defesa = 1;
        }

        if (y == 4)
        {
            vida = vida + 5;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().defesa = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().defesa - 2;
        }
    }
}
