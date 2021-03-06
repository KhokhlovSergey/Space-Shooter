﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollisions : MonoBehaviour {

    // Use this for initialization
    public GameObject explosion;
    public GameObject playerExplosion;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary") {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Debug.Log(other.name);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
