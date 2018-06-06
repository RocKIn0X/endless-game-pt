using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float force;
    public Text scoreText;

    private float horizontal_dir;
    private float jump;
    private float z_min;
    private float z_max;
    private int score;
    private int scoreToNextLevel;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 0.3f;
        score = 0;
        scoreToNextLevel = 20;
        scoreText.text = "Score: " + score.ToString();
        z_min = -6.5f;
        z_max = 6.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontal_dir = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(1f, 0f, -horizontal_dir);

        //rb.AddForce(movement * speed);
        transform.position += movement * speed;

        float new_z = Mathf.Clamp(transform.position.z, z_min, z_max);
        transform.position = new Vector3(transform.position.x, transform.position.y, new_z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            score += 1;
            scoreText.text = "Score: " + score.ToString();

            if (score >= scoreToNextLevel)
            {
                speed += 0.1f;
                scoreToNextLevel += 20;
            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit obstacle");
            speed = 0;
        }
    }
}
