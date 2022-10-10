using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
