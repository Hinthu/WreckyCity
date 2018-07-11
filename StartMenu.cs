using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public static bool gameIsPaused = false;

	public GameObject startMenuUI;

	public GameObject statsUI;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		startMenuUI.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(gameIsPaused)
		{
		}
		if(!gameIsPaused)
		{
		}

	}

	public void StartGame ()
	{
		startMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		statsUI.SetActive(true);

		/*if (FindObjectOfType<CarController>().curHealth <= 0 || FindObjectOfType<PlayZoner>().isDead == true)
		{
			Debug.Log("DEAD!!!");
			SceneManager.LoadScene("Main");
		}//bob

		*/
	}

	public void EndGame ()
	{
		startMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
		FindObjectOfType<WB>().UpdateHighScore();
	}
}
