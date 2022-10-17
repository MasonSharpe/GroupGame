using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject AreYouSure;
    public GameObject gameOver;
    private void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<Canvas>().enabled == false && gameOver.GetComponent<Canvas>().enabled == false)

        {
            if (Time.timeScale != 0)
            {
                //Pause the Game
                PauseGame();
            }
            else
            {
                //Resume Game
                Resume();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        GetComponent<Canvas>().enabled = true;
    }
    public void Resume()
    {
        //Resume the game, Unpause
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void MainMenuCheck()
    {
        AreYouSure.GetComponent<Canvas>().enabled = true;
    }
    public void Close()
    {
        AreYouSure.GetComponent<Canvas>().enabled = false;
    }
    //public void Controls()
    //{
    //SceneManager.LoadScene("Controls");
    //Time.timeScale = 0;
    //}
}
