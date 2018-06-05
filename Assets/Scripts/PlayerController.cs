using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 1f;
    public float force = 10f;

    private float horizontal_dir;
    private float jump;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontal_dir = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(0.5f, 0f, -horizontal_dir);

        rb.AddForce(movement * speed);
        transform.position += movement * speed;
    }
}
