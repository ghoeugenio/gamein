using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barril : MonoBehaviour {

    public GameObject prefab_explosao_barril;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {

        float x, y;
        Quaternion qua;
        Vector2 vec;

        if ((collision.gameObject.tag == "projetil") || (collision.gameObject.tag == "projetil2"))
        {
            x = transform.position.x;
            y = transform.position.y;
            qua = transform.rotation;
            vec = new Vector2(x, y);
            Instantiate(prefab_explosao_barril, vec, qua);
            Destroy(gameObject);
        }
    }
}
