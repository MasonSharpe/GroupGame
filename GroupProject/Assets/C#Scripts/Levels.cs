using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    void Update()
    {
        GetComponent<Canvas>().enabled = true;
    }
    public void Level1()
	{
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
	}
    public void Level2()
	{
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
	}
    public void Level3()
	{
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
	}
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1;
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
        Time.timeScale = 1;
    }
}
