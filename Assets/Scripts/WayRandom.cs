using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, RandomZpos());
        print(transform.position);
    }

    float RandomZpos()
    {
        float z = Random.Range(-4, 5);

        return z;
    }
}
