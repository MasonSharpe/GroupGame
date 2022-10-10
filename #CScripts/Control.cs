using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    //void Update()
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
        Time.timeScale = 0;
    }
    public void Close()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = true;
    }
    public void PauseGame()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = true;
    }
}
