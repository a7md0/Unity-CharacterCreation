using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public float jogSpeed, runSpeed, jumpPower, turnSpeed;
    private float xInput, zInput;
    private float speed;
    private Vector3 movement;
    private Rigidbody body;

    private RaycastHit ray;
    private bool hit = false;
    private CapsuleCollider capsuleCollider;
    private float height;

    // Use this for initialization
    void Start() {
        body = GetComponent<Rigidbody>();
        speed = jogSpeed;

        capsuleCollider = GetComponent<CapsuleCollider>();
        height = capsuleCollider.height;
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
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
        }

        float y = body.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround()) {
            y = jumpPower;
        }

        //Finally, change velocity to move body
        body.velocity = new Vector3(movement.x, y, movement.z);
    }

    private bool IsOnGround() {
        Vector3 origin = transform.position + transform.up * (height - 0.1f);
        Vector3 destination = -transform.up;

        hit = Physics.Raycast(origin, destination, out ray, height);

        //Optionally, we can draw the ray in the scene view (not in-game)  to visualize it for testing
        Debug.DrawRay(origin, destination * height, Color.blue);

        //We only process the result of the casted ray IF it hits anything.
        if (hit && ray.collider.gameObject.tag == "Ground") {
            return true;
        }

        return false;
    }
}
