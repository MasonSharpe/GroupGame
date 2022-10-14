using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       {
           Time.timeScale = 0;
           GetComponent<Canvas>().enabled = true;
        }
    }
    public void NextLevel(int number)
    {
        SceneManager.LoadScene("Level" + number);
    }
}
