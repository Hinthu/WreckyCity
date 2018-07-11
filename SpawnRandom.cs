using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : PoolObject
{
	[System.Serializable]
	public class SpawnAll
	{
		public GameObject objToSpawn;
		public int count;
		
	}

	public SpawnAll[] spawnAlls;

	public float area;


	void Awake()
	{
		for (int i = 0; i < spawnAlls.Length; i++)
		{
			SpawnAllObj(spawnAlls[i]);
		}
	}

	void SpawnAllObj(SpawnAll _spawnAll)
	{

		for (int i = 0; i < _spawnAll.count; i++)
		{
			SpawnObj(_spawnAll.objToSpawn);
		}


	}

	public void SpawnObj(GameObject _objToSpawn)
	{
		Vector3 randomSpawnPos = new Vector3(transform.position.x + Random.Range(-area, area),transform.position.y, transform.position.z + Random.Range(-area, area));
		GameObject Clone = Instantiate(_objToSpawn, randomSpawnPos, Quaternion.identity);
		Clone.transform.SetParent(this.transform);
	}

}