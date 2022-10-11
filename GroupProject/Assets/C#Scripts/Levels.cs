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

    public void SelectLevel(int number)
    {
        SceneManager.LoadScene("Level" + number);
        Time.timeScale = 1;
    }
}
