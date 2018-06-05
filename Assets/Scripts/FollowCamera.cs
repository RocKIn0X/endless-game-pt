using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private Transform lookAt;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = lookAt.position + offset;
	}
}
