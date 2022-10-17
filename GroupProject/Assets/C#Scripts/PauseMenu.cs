using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject AreYouSure;
    private void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<Canvas>().enabled == false)

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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void MainMenuCheck()
    {
        AreYouSure.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
    }
    public void Close()
    {
        Time.timeScale = 0;
        AreYouSure.GetComponent<Canvas>().enabled = false;
    }
    //public void Controls()
    //{
    //SceneManager.LoadScene("Controls");
    //Time.timeScale = 0;
    //}
}
