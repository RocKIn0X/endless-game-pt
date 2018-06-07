using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreText : MonoBehaviour {
    TextMeshProUGUI highscoreText;


	// Use this for initialization
	void Start () {
        highscoreText = GetComponent<TextMeshProUGUI>();
        highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
