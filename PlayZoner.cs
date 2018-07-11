using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZoner : MonoBehaviour {

	public Transform player;

	StartMenu startMenu;

	public float maxAliveTime = 3f;

	float curAliveTime;

	public GameObject RedFlashImage;

	public GameObject WarningText;

	public int playArea = 200;

	public bool isDead = false;

	bool isInBounds = true;

	void Start()
	{
		curAliveTime = maxAliveTime;
	}

	bool IsInSquare(int map_center_x, int map_center_y, int square_length, int car_pos_x, int car_pos_y)
	{

		bool is_inside_in_x_direction = car_pos_x <= map_center_x + square_length / 2 && car_pos_x >= map_center_x - square_length / 2;
		bool is_inside_in_y_direction = car_pos_y <= map_center_y + square_length / 2 && car_pos_y >= map_center_y - square_length / 2;
		return is_inside_in_x_direction && is_inside_in_y_direction;
	}


	void Update ()
	{
		isInBounds = IsInSquare((int)this.gameObject.transform.position.x, (int)this.gameObject.transform.position.z, playArea, (int)player.transform.position.x, (int)player.transform.position.z);

		if(!isInBounds)
		{
			/*
			print("mapx-" + (int)this.gameObject.transform.position.x);
			print("mapy-" + (int)this.gameObject.transform.position.z);
			print("playx-" + (int)player.transform.position.x);
			print("playy-" + (int)player.transform.position.z);
			*/
			OnOutsideZone();

			RedFlashImage.SetActive(true);

			WarningText.SetActive(true);
		}
		else if (isInBounds)
		{
			curAliveTime = maxAliveTime;
			isDead = false;

			RedFlashImage.SetActive(false);
			WarningText.SetActive(false);
		}
	}

	void OnOutsideZone ()
	{ 

		DecreaseTime();

		

		if (!isInBounds && curAliveTime <= 0)
		{
			FindObjectOfType<StartMenu>().EndGame();
			Debug.Log("DEAD MOTHERTRUCKER ahahhahaha");
			//FindObjectOfType<GM>().GoToStartScreen();
			isDead = true;
		}
	}

	void DecreaseTime ()
	{
		if(curAliveTime > 0 && !isInBounds)
		{
			curAliveTime -= Time.deltaTime;
		}
		else
		{
			curAliveTime = maxAliveTime;
		}
		
	}
}

