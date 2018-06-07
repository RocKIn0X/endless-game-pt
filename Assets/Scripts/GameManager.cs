using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI highscoreText;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetHighscore ()
    {
        PlayerPrefs.DeleteAll();
        highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
