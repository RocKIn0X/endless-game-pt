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
        float z = Random.Range(-4, 4);
        print("Random z: " + z);

        return z;
    }
}
