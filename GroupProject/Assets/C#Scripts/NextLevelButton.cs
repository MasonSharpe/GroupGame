using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    Vector3 mouseTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
			mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		}
	}
	public void SelectLevel(int number)
	{
		SceneManager.LoadScene("Level" + number);
		Time.timeScale = 1;
	}
}
