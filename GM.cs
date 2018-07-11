using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
	public GameObject startZone;
	 
	// Use this for initialization
	void Start ()
	{
		startZone.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time > 3f)
		{
			DisableStartZone();
		}
	}

	public void StartOver ()
	{
		print("GM gameover");
		SceneManager.LoadScene("Main");
	}

	public void GoToStartScreen()
	{
		SceneManager.LoadScene("StartMenu");
	}

	void DisableStartZone()
	{
		startZone.SetActive(false); 
	}

}
