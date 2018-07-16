using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projetil2 : MonoBehaviour {

    public GameObject player;
    public GameObject prefab_projetil, prefab_explosao, prefab_portal;
    public float pro_str, pro_angle;
    private bool pro_v, c_lan, pressleft, pressright, t_ventovef, destroi, naoexplodiu, desgrude, destroidois, jahitou;
    public bool pro_direcao, pressk;
    private Vector2 pro_posicao, p_posicao;
    public GameObject jogar;
    public int crit, dano, total;
    public GameObject setinha, setinhaclone;
    private float t_vento, esperar, esperapouca;
    public GameObject symum;
    public Text printdano;

    // Use this for initialization
    void Start () {
        pro_str = 1.0f;
        pro_angle = 2.0f;
        dano = 10;
        t_vento = 0.5f;
        pressk = false;
        esperar = 2f;
        destroi = false;
        destroidois = false;
        naoexplodiu = true;
        desgrude = false;
        jahitou = true;
    }

    // Update is called once per frame
    void Update () {

        if (GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind < 0)
        {
            symum.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            symum.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (destroi)
        {
            esperar -= Time.deltaTime;
            if (esperar < 0)
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
                Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil 
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
                GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().prefab_projetil.GetComponent<projetil2>().dano = 10;
            }
        }

        if (destroidois)
        {
            printdano.fontSize = 25 + (crit * 4);
            esperar -= Time.deltaTime;
            printdano.text = total.ToString();
            if (esperar < 0)
            {
                //Destroy(gameObject); 
                GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
                Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = true;
                GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
                GameObject.FindGameObjectWithTag("jogada2").GetComponent<projetil2>().prefab_projetil.GetComponent<projetil2>().dano = 10;
            }
        }


        if (c_lan)
        {
            setinha.transform.eulerAngles = new Vector3(0, 0, -50);
            setinhaclone.transform.eulerAngles = new Vector3(0, 0, 50);
            c_lan = false;
        }

        if (Input.GetKey(KeyCode.H))//direciona a palheta pra baixo
        {
            if (pro_angle > 0.1f)//limite de anglo
            {
                pro_angle -= 0.02f;//constante de alteracao da direcao
                if (pro_direcao)
                {
                    setinha.transform.eulerAngles = new Vector3(0, 0, setinha.transform.eulerAngles.z - 0.4f);
                }
                else
                {
                    setinhaclone.transform.eulerAngles = new Vector3(0, 0, setinhaclone.transform.eulerAngles.z + 0.4f);
                }
            }
        }
        if (Input.GetKey(KeyCode.Y))//direciona a palheta pra cima
        {
            if (pro_angle <= 4f)//limite de anglo
            {
                pro_angle += 0.02f;//constante de alteracao da direcao
                if (pro_direcao)
                {
                    setinha.transform.eulerAngles = new Vector3(0, 0, setinha.transform.eulerAngles.z + 0.4f);
                }
                else
                {
                    setinhaclone.transform.eulerAngles = new Vector3(0, 0, setinhaclone.transform.eulerAngles.z - 0.4f);
                }
            }
        }

        if (Input.GetKey(KeyCode.N) && GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo)//enquanto c estiver apertado
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            pro_str += Time.deltaTime;//contagem da forca de acordo com o tempo
            pro_v = true;//verificador para lancamento
            if (pro_str > 13f)
            {
                print("overcarry");
                pro_str = 1;//limitador de forca de lancamento
            }
            esperapouca = 0.5f;
            //GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = false;
        }

        if (Input.GetKey(KeyCode.U))    //escolha da direcao
        {
            if (pressright)
            {
                pro_angle = 2f;
                setinhaclone.transform.eulerAngles = new Vector3(0, 0, 50);
            }
            pressleft = true;
            pressright = false;
            pro_direcao = false;
            setinha.SetActive(false);
            setinhaclone.SetActive(true);
        }

        if (Input.GetKey(KeyCode.O))    //escolha da direcao
        {
            if (pressleft)
            {
                pro_angle = 2f;
                setinha.transform.eulerAngles = new Vector3(0, 0, -50);
            }
            pressleft = false;
            pressright = true;
            pro_direcao = true;
            setinhaclone.SetActive(false);
            setinha.SetActive(true);

        }

        if ((Input.GetKeyUp(KeyCode.N) && pro_v))//quando c eh solto
        {
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantwo = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            p_posicao = GameObject.FindGameObjectWithTag("player2").transform.position;
            p_posicao = new Vector2(p_posicao.x, p_posicao.y + 0.3f);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            if (pressk)
            {
                Instantiate(prefab_portal, p_posicao, transform.rotation);
                pressk = false;
                if (pro_direcao)//sentido do lanncamento
                {
                    GameObject.FindGameObjectWithTag("portal").GetComponent<Rigidbody2D>().velocity = new Vector2(pro_str, (pro_str * pro_angle));
                }
                else
                {
                    GameObject.FindGameObjectWithTag("portal").GetComponent<Rigidbody2D>().velocity = new Vector2((pro_str * (-1f)), (pro_str * pro_angle));
                }
            }
            else
            {
                Instantiate(prefab_projetil, p_posicao, transform.rotation);
                if (pro_direcao)//sentido do lanncamento
                {
                    GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity = new Vector2(pro_str, (pro_str * pro_angle));
                }
                else
                {
                    GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity = new Vector2((pro_str * (-1f)), (pro_str * pro_angle));
                }
            }
            t_ventovef = true;

            pro_v = false;//verificador para lancamento
            pro_str = 1f;//forca inicial
            pro_angle = 2.0f;//anglo inicial
            c_lan = true;
            t_vento = 0.5f;
        }

        if (t_ventovef && !pressk)
        {
            t_vento -= Time.deltaTime;
            if (t_vento < 0)
            {
                t_ventovef = false;
                GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity.x + (GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind), GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            pressk = true;
        }

        esperapouca -= Time.deltaTime;
        if (esperapouca < 0)
        {
            desgrude = true;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        float x, y;
        Quaternion qua;
        Vector2 vec;

        /*if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco"))//verifica se colidio com o chao
        {
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            x = GameObject.FindGameObjectWithTag("projetil2").transform.position.x;
            y = GameObject.FindGameObjectWithTag("projetil2").transform.position.y;
            qua = GameObject.FindGameObjectWithTag("projetil2").transform.rotation;
            vec = new Vector2(x, y);
            Destroy(GameObject.FindGameObjectWithTag("projetil2"));            //destroi o projetil
            Instantiate(prefab_explosao, vec, qua);
            /*GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            GameObject.FindGameObjectWithTag("chao").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
        }*/
    
        if (((collision.gameObject.tag == "bloco") || (collision.gameObject.tag == "chao") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco")) && jahitou)
        {
            jahitou = false;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            //GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            //GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            if (collision.gameObject.tag == "bloco")
            {
                Destroy(collision.gameObject);
            }
            if (naoexplodiu)
            {
                naoexplodiu = false;
                x = GameObject.FindGameObjectWithTag("projetil2").transform.position.x;
                y = GameObject.FindGameObjectWithTag("projetil2").transform.position.y;
                qua = GameObject.FindGameObjectWithTag("projetil2").transform.rotation;
                vec = new Vector2(x, y);
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<SpriteRenderer>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<BoxCollider2D>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Animation>());
                //Destroy(GameObject.FindGameObjectWithTag("projetil"));            //destroi o projetil
                Instantiate(prefab_explosao, vec, qua);
            }
            GameObject.FindGameObjectWithTag("AllBlocos").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().inc_rodadas();
        }

        if (collision.gameObject.tag == "Player" && jahitou)
        {
            jahitou = false;
            crit = Random.Range(1, 10);
            total = dano + crit;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().tdj = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().acertou(total);
            GameObject.FindGameObjectWithTag("hit").GetComponent<AudioSource>().Play();
            destroidois = true;
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<SpriteRenderer>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<BoxCollider2D>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Animation>());
            Update();
        }

        if (collision.gameObject.tag == "barril")
        {
            destroi = true;
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<SpriteRenderer>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<BoxCollider2D>());
            Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Animation>());
            Update();
        }

        if (collision.gameObject.tag == "player2")
        {
            if (desgrude)
            {
                destroi = true;
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<SpriteRenderer>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Rigidbody2D>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<BoxCollider2D>());
                Destroy(GameObject.FindGameObjectWithTag("projetil2").GetComponent<Animation>());
                Update();
            }
        }
    }
}
