using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health <= 0)
        {
            Time.timeScale = 0;
            GetComponent<Canvas>().enabled = true;
            Player.health = 10;
        }
    }
}
