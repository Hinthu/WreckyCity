using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destructible : MonoBehaviour {

	//public GameObject destroyedVersion;

	public int area = 100;

	//public float health = 100f;

	//public void DecreaseHealth ()
	//{
	//health -= 10f;
	//}
	public float ForceAmount;
	void Update ()
	{

		//if(health <= 0f)
		//{
			//CrackObject();
		//}

		//print(health);

	}

	public void CrackObject ()
	{
		//GameObject destroyedVer = Instantiate(destroyedVersion, transform.position, transform.rotation);
		//Destroy(destroyedVer, 5f);
		//Destroy(gameObject);
		this.gameObject.SetActive(false);
	
		Vector3 randomSpawnPos = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
		transform.position = randomSpawnPos;

		this.gameObject.SetActive(true);

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "WB")
		{
			if(this.gameObject.tag == "Building")
			{
				FindObjectOfType<TopCameraFollow>().shouldShake = true;
				PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().buildingExplosionPrefab, transform.position, Quaternion.identity);
			}
			else if (this.gameObject.tag == "tree")
			{
				PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().treeExplosionPrefab, transform.position, Quaternion.identity);
			}
			else if(this.gameObject.tag == "missileLauncher")
			{
				FindObjectOfType<TopCameraFollow>().shouldShake = true;
				PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab, transform.position, Quaternion.identity);
			}
			
			//if(col.impactForceSum.magnitude > ForceAmount)
			//{
			//DecreaseHealth();
			CrackObject();
			FindObjectOfType<TopCameraFollow>().shouldShake = true;

		}


		if (col.gameObject.tag == "Building" || col.gameObject.tag == "StartZone")
		{
			
			Vector3 randomSpawnPos = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
			transform.position = randomSpawnPos;
		}
		else if(col.gameObject.tag == "Player")
		{
			CrackObject();
		}
	}


}
