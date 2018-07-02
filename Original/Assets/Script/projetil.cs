using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour {

    public GameObject player;
    public GameObject prefab_projetil, prefab_explosao, prefab_portal;
    public float pro_str, pro_angle;
    private bool pro_v, c_lan, pressleft, pressright, t_ventovef;
    public bool pro_direcao, pressz;
    private Vector2 pro_posicao, p_posicao;
    public GameObject jogar;
    public int crit, dano, total;
    public GameObject setinha, setinhaclone;
    private float t_vento;
    
	// Use this for initialization
	void Start () {
        pro_str = 1.0f;
        pro_angle = 2.0f;
        dano = 10;
        t_vento = 0.5f;
        pressz = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (c_lan)
        {
            setinha.transform.eulerAngles = new Vector3(0, 0, -50);
            setinhaclone.transform.eulerAngles = new Vector3(0, 0, 50);
            c_lan = false;
        }
        
        if (Input.GetKey(KeyCode.F))//direciona a palheta pra baixo
        {
            if (pro_angle > 1.1f)//limite de anglo
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
        if (Input.GetKey(KeyCode.R))//direciona a palheta pra cima
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

        if (Input.GetKey(KeyCode.C) && GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum)//enquanto c estiver apertado
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            pro_str += Time.deltaTime;//contagem da forca de acordo com o tempo
            pro_v = true;//verificador para lancamento
            if (pro_str > 13f)
            {
                print("overcarry");
                pro_str = 1;//limitador de forca de lancamento
            }
        }

        if (Input.GetKey(KeyCode.Q))    //escolha da direcao
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

        if (Input.GetKey(KeyCode.E))    //escolha da direcao
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

        if ((Input.GetKeyUp(KeyCode.C) && pro_v))//quando c eh solto
        {
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            p_posicao = GameObject.FindGameObjectWithTag("Player").transform.position;
            p_posicao = new Vector2(p_posicao.x, p_posicao.y + 0.3f);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = false;
            if (pressz)
            {
                Instantiate(prefab_portal, p_posicao, transform.rotation);
                if (pro_direcao)//sentido do lanncamento
                {
                    //print("esquerda");
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
                    //print("esquerda");
                    GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>().velocity = new Vector2(pro_str, (pro_str * pro_angle));
                }
                else
                {
                    GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>().velocity = new Vector2((pro_str * (-1f)), (pro_str * pro_angle));
                }
            }
            t_ventovef = true;
            
            pro_v = false;//verificador para lancamento
            pro_str = 1f;//forca inicial
            pro_angle = 2.0f;//anglo inicial
            c_lan = true;
        }

        if (t_ventovef && !pressz)
        {
            t_vento -= Time.deltaTime;
            if (t_vento < 0)
            {
                t_ventovef = false;
                GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>().velocity.x + (GameObject.FindGameObjectWithTag("vento").GetComponent<vento>().wind), GameObject.FindGameObjectWithTag("projetil").GetComponent<Rigidbody2D>().velocity.y);
            }
            print("pass");

        }

        if (Input.GetKey(KeyCode.Z))
        {
            pressz = !pressz;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        float x, y;
        Quaternion qua;
        Vector2 vec;

        if ((collision.gameObject.tag == "chao") || (collision.gameObject.tag == "limite") || (collision.gameObject.tag == "limiteclone") || (collision.gameObject.tag == "calco"))//verifica se colidio com o chao
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            x = GameObject.FindGameObjectWithTag("projetil").transform.position.x;
            y = GameObject.FindGameObjectWithTag("projetil").transform.position.y;
            qua = GameObject.FindGameObjectWithTag("projetil").transform.rotation;
            vec = new Vector2(x, y);
            Destroy(GameObject.FindGameObjectWithTag("projetil"));            //destroi o projetil
            Instantiate(prefab_explosao, vec, qua);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            GameObject.FindGameObjectWithTag("chao").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
        }

        if (collision.gameObject.tag == "bloco")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("projetil"));            //destroi o projetil
            GameObject.FindGameObjectWithTag("AllBlocos").GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
        }

        if (collision.gameObject.tag == "player2")
        {
            crit = Random.Range(1, 10);
            total = dano + crit;
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().tdj = 0;
            GameObject.FindGameObjectWithTag("player2").GetComponent<player2>().acertou(total);
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vez = true;
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().vezdois = false;
            Destroy(GameObject.FindGameObjectWithTag("projetil"));
            GameObject.FindGameObjectWithTag("jogar").GetComponent<jogar>().cantum = true;
            GameObject.FindGameObjectWithTag("hit").GetComponent<AudioSource>().Play();
        }
    }
}
