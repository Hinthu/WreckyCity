using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WB : MonoBehaviour
{
	public float timeBetweenDestroy = 3f;

	public bool hasHitObject = false;

	bool ifHasHitObject = false;

	int score3 = 3;
	int score10 = 10;
	int score20 = 20;
	int score30 = 30;
	int score40 = 40;
	int score50 = 50;

	int score = 0;

	public Text scoreText;

	public Text highScoreText;

	// Use this for initialization
	void Start () {
		highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (ifHasHitObject)
		{
			hasHitObject = true;

			ifHasHitObject = false;
		}
			
		
		else if(!ifHasHitObject)
		{
			hasHitObject = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == 8)
		{
			score += score3;
			UpdateText();
		}
		else if (col.gameObject.layer == 9)
		{
			score += score10;
			UpdateText();
		}
		else if (col.gameObject.layer == 10)
		{
			score += score20;
			UpdateText();
		}
		else if (col.gameObject.layer == 11)
		{
			score += score30;
			UpdateText();
		}
		else if (col.gameObject.layer == 12)
		{
			score += score40;
			UpdateText();
		}
		else if (col.gameObject.layer == 13)
		{
			score += score50;
			UpdateText();
		}

		if (col.gameObject.tag == "Building")
		{

			ifHasHitObject = true;
		}
		


	}

	public void UpdateHighScore ()
	{
		if (score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreText.text = score.ToString();
		}
	}
	
	void UpdateText ()
	{
		scoreText.text = "Score: " + score.ToString();
			
	}
}
