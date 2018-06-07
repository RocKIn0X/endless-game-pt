using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHighscoreTile(bool isHighscore)
    {
        gameObject.transform.GetChild(transform.childCount - 1).gameObject.SetActive(isHighscore);
    }
}
