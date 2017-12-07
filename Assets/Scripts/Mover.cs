using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed = 22.0f;
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = rb.transform.forward * speed;
    }
}
