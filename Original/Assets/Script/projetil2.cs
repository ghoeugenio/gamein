using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil2 : MonoBehaviour {

    public GameObject player;
    //public GameObject cam_projetil;
    //public GameObject cam_char;
    public GameObject prefab_projetil;
    //private Rigidbody2D pro_rigidbody;
    public float pro_str, pro_angle;
    private bool pro_v;
    public bool pro_direcao;
    //public bool pro_collider;
    private Vector2 pro_posicao, p_posicao;
    public GameObject jogar;
    public int crit, dano = 10, total;

    // Use this for initialization
    void Start () {
        //pro_rigidbody = GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>();
        pro_str = 1.0f;
        pro_angle = 2.0f;
        //GameObject.FindGameObjectWithTag("campro").SetActive(false);
        //gameObject.SetActive(false);
        // pro_tape = true;
        //GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
    }

    // Update is called once per frame
    void Update () {
        //GameObject.FindGameObjectWithTag("player").transform.position = GameObject.FindGameObjectWithTag("projetil").transform.position;

        //gameObject.transform.position = GameObject.FindGameObjectWithTag("player").transform.position;

        //pro_collider = false;

        if (Input.GetKey(KeyCode.H))//direciona a palheta pra baixo
        {
            if (pro_angle >= 1f)//limite de anglo
            {
                pro_angle -= 0.02f;//constante de alteracao da direcao
            }
        }
        if (Input.GetKey(KeyCode.Y))//direciona a palheta pra cima
        {
            if (pro_angle <= 6f)//limite de anglo
            {
                pro_angle += 0.02f;//constante de alteracao da direcao
            }
        }

        if (Input.GetKey(KeyCode.N) && GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo)//enquanto c estiver apertado
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            pro_str += Time.deltaTime;//contagem da forca de acordo com o tempo
            pro_v = true;//verificador para lancamento
            if (pro_str > 10f)
            {
                print("overcarry");
                pro_str = 1;//limitador de forca de lancamento
            }
            //GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = false;
        }

        if (Input.GetKey(KeyCode.U))    //escolha da direcao
        {
            pro_direcao = false;
        }

        if (Input.GetKey(KeyCode.O))    //escolha da direcao
        {
            pro_direcao = true;
        }

        if ((Input.GetKeyUp(KeyCode.N) && pro_v))//quando c eh solto
        {
            //p_posicao = new Vector2(player.transform.position.x + 0.3f, player.transform.position.y);
            //pro_posicao = transform.position;       //guarda a posicao onde o projetil estava
            //pro_posicao = new Vector2(0, 5);
            //cam_char.GetComponent<campro>().setter();
            //cam_projetil.GetComponent<camper>().unsetter();//transferencia de camera
            //cam_char.SetActive(true);
            //cam_projetil.SetActive(false);
            //pro_tape = false;
            //GameObject.FindGameObjectWithTag("campro").SetActive(true);
            //GameObject.FindGameObjectWithTag("camper").SetActive(false);
            //pro_collider = !pro_collider;
            //print(player.tag);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            p_posicao = GameObject.FindGameObjectWithTag("player2").transform.position;
            p_posicao = new Vector2(p_posicao.x, p_posicao.y + 0.3f);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            Instantiate(prefab_projetil, p_posicao, transform.rotation);
            //GameObject.FindGameObjectWithTag("campro").SetActive(true);
            //GameObject.FindGameObjectWithTag("camper").SetActive(false);
            //print("angle: " + pro_angle);
            if (pro_direcao)//sentido do lanncamento
            {
                //print("esquerda");
                GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity = new Vector2((pro_str)- GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind, (pro_str * pro_angle));
            }
            else
            {
                //print("direita");
                GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity = new Vector2((pro_str * (-1f)) - GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind, (pro_str * pro_angle));
            }
            pro_v = false;//verificador para lancamento
            //print(pro_str);
            pro_str = 1f;//forca inicial
            pro_angle = 2.0f;//anglo inicial
            
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco"))//verifica se colidio com o chao
        {
            //gameObject.SetActive(false);
            //pro_tape = true;
            //GameObject.FindGameObjectWithTag("camper").SetActive(true);
            //GameObject.FindGameObjectWithTag("campro").SetActive(false);
            //cam_char.SetActive(true);
            //cam_projetil.SetActive(false);
            //pro_collider = true;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
            Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil
            GameObject.FindGameObjectWithTag("chao").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
            //Thread.Sleep(1000);                 //aguarda 2s
            //cria outro no lugar onnde ele estava
            //cam_projetil.GetComponent<campro>().unsetter();
            //cam_char.GetComponent<camper>().setter();   //transfere a camera pro personagem novamente
            //cam_char.SetActive(false);
            //cam_projetil.SetActive(true);
        }

        if (collision.gameObject.tag == "bloco")
        {
            //pro_tape = true;
            //GameObject.FindGameObjectWithTag("camper").SetActive(true);
            //GameObject.FindGameObjectWithTag("campro").SetActive(false);
            //cam_char.SetActive(true);
            //cam_projetil.SetActive(false);
            //pro_collider = true;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
            Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil
            GameObject.FindGameObjectWithTag("AllBlocos").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            crit = Random.Range(1, 10);
            total = dano + crit;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().acertou(total);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
            Destroy(GameObject.FindGameObjectWithTag("projetil2"));
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
            GameObject.FindGameObjectWithTag("hit").GetComponent<AudioSource>().Play();
        }

        //return pro_collider = true;
    }
}
