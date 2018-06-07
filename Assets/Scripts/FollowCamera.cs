using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    //public float smoothSpeed = 0.125f;


    private Transform target;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        transform.position = target.position + offset;
	}
}
