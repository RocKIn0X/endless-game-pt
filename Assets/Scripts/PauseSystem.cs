using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour {

    public static bool IsGamePause = false;

    public GameObject pauseUI;

    private string scene_game = "Game";
    private string scene_menu = "Menu";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (IsGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Pause ()
    {
        Time.timeScale = 0f;
        IsGamePause = true;
        pauseUI.SetActive(true);
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        IsGamePause = false;
        pauseUI.SetActive(false);
    }


    public void Restart ()
    {
        Time.timeScale = 1f;
        IsGamePause = false;
        SceneManager.LoadScene(scene_game);
        
    }

    public void Menu ()
    {
        Time.timeScale = 1f;
        IsGamePause = false;
        SceneManager.LoadScene(scene_menu);        
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
