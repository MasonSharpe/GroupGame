using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Yes()
	{
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
	}
    public void No()
	{
        GetComponent<Canvas>().enabled = false;
	}
}
