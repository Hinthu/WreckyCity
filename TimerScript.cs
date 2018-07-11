using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

	Image timerBar;
	public float maxTime = 3f;
	float timeLeft;

	public GameObject wreckingBall;

	WB wBScript;

	// Use this for initialization
	void Start ()
	{
		
		timerBar = GetComponent<Image>();
		timeLeft = maxTime;

		wBScript = wreckingBall.GetComponent<WB>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DecreaseTime();
		
		if (timeLeft <= 0 && wBScript.hasHitObject == false)
		{
			FindObjectOfType<GM>().StartOver();
			
		}
		
		if(wBScript.hasHitObject == true)
		{
			timeLeft = maxTime;
			timerBar.fillAmount = 1;
			
		}
	}

	public void DecreaseTime ()
	{
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timerBar.fillAmount = timeLeft / maxTime;

		}
	}
}
