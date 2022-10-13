using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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
		SceneManager.LoadScene("Level1");
		Time.timeScale = 1;
	}
	public void Quit()
	{
		Application.Quit();
	}
	public void levelSelect()
	{
		SceneManager.LoadScene("LevelSelection");
		Time.timeScale = 1;
	}
}