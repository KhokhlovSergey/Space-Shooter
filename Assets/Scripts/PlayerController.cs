using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary {
    public float minX = -7.05f, maxX = 7.05f, minZ = -3.5f, maxZ = 9f;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    float moveHorizontal;
    float moveVertical;
    private Boundary boundary;
    private float tilt = 5;
    private AudioSource soundSource;

    private Rigidbody rigidBody;


    public GameObject shot;
    public Transform shotSpawn;
    
    public float fireRate = 0.25f;
    public float nextFire = 0.0f;

    private void Update() {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);           // create code here that animates the newProjectile            nextFire = nextFire - myTime;
            soundSource.Play();
        }
            
    }

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
        soundSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.velocity = movement * speed;
        boundary = new Boundary();
        rigidBody.position = new Vector3(
            Mathf.Clamp(rigidBody.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.minZ, boundary.maxZ)
            );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
        
    }
}
