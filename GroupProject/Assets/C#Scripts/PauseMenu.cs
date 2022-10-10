using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    //public void Restart()
    //{
        //Time.timeScale = 1;
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    //}
    //public void MainMenu()
    //{
        //SceneManager.LoadScene("SampleScene");
    //}
    //public void Close()
    //{
        //Time.timeScale = 0;
        //GetComponent<Canvas>().enabled = true;
    //}
    //public void Controls()
    //{
        //SceneManager.LoadScene("Controls");
        //Time.timeScale = 0;
    //}
}
