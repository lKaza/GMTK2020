using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();

            }else{
                Pause();
            }
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
    }

    public void Resume()
    {  
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void Quit(){
        Application.Quit();
    }
    public void GameOverScreen(){
        GameOverUI.SetActive(true);
        
    }

    public void Reload(){
        Scene scene = SceneManager.GetActiveScene();
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(scene.buildIndex);

    }

}
