using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    //Vector3 mouseTarget;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
       // if (Input.GetButtonDown("Fire2"))
       // {
			//mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//}
	//}
	//public void SelectLevel(int number)
	//{
		//SceneManager.LoadScene("Level" + number);
		//Time.timeScale = 1;
	//}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "TutorialLevel")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            Player.health = Player.maxHealth;
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            SceneManager.LoadScene("Level" + (player.GetComponent<Player>().level + 1).ToString());
        }
    }
}
