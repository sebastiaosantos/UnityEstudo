﻿using UnityEngine;
using System.Collections;

public class AtaqueEspecial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Inimigo")
        {
            Destroy(colisor.gameObject);
        }
    }
}
