using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //chileObj = GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
