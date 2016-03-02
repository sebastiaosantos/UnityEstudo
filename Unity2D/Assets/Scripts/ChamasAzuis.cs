﻿using UnityEngine;
using System.Collections;

public class ChamasAzuis : MonoBehaviour {

    public float velocidade;
    public int dano;
    // Use this for initialization
    void Start () {

        Destroy(gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.right * velocidade * Time.deltaTime);


    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            var player = colisor.gameObject.transform.GetComponent<Vida>();
            player.Damage(dano);
        }
        Destroy(gameObject);
    }
}
