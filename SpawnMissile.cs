using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour {

	public int area = 100;

	public float timerValue = 3f;

	public Transform[] missileLunchers;



	float timer;

	void Start ()
	{
		timer = timerValue;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEverySeconds();
	}

	public void SpawnRandomMissile ()
	{
		//Vector3 randomSpawnPos = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
		//mMissilePool.InstantiateItem(randomSpawnPos, Quaternion.identity);
		Transform sp = missileLunchers[Random.Range(0,missileLunchers.Length)];

		PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().missilePrefab,sp.position, Quaternion.identity);
	}

	void SpawnEverySeconds ()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;

			
		}
		else if (timer <= 0)
		{
			SpawnRandomMissile();
			timer = timerValue;

		}

		
	}
}
