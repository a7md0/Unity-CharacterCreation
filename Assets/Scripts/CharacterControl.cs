using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public float jogSpeed, runSpeed, jumpPower, turnSpeed;
    private float xInput, zInput;
    private float speed;
    private Vector3 movement;
    private Rigidbody body;

    // Use this for initialization
    void Start() {
        body = GetComponent<Rigidbody>();
        speed = jogSpeed;
    }

    // Update is called once per frame
    void Update() {
        //Get movement input
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        //Check if we are running, then set the appropriate speed.
        if (Input.GetAxis("Run") > 0.1f) {
            speed = runSpeed;
        } else {
            speed = jogSpeed;
        }

        //Set movement
        movement = new Vector3(xInput, 0, zInput) * 100 * speed * Time.deltaTime;

        //Rotate body towards movement direction
        if (movement.magnitude != 0) {
            transform.rotation =
            Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
        }

        //Finally, change velocity to move body
        body.velocity = new Vector3(movement.x, body.velocity.y, movement.z);
    }
}
