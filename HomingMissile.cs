using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : PoolObject {

	public Transform target;

	public float rotateSpeed = 300f;

	public float speed = 5f;

	int area = 100;

	private Rigidbody rb;

	public override void OnObjectReuse()
	{
		rb = GetComponent<Rigidbody>();

		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		Vector3 direction = target.position - rb.position;
		direction.Normalize();
		Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);
		rb.angularVelocity = rotateAmount * rotateSpeed;
		rb.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "BoxDect" || col.gameObject.tag == "WB")
		{
			/*GameObject explodeParticle = Instantiate(particleExplodePrefab, transform.position, transform.rotation);
			Destroy(explodeParticle, 3f);

			Vector3 randomSpawnPos = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
			transform.position = randomSpawnPos;
			//if(col.impactForceSum.magnitude > ForceAmount)
			//{
			//DecreaseHealth();
			FindObjectOfType<TopCameraFollow>().shouldShake = true;
			*/

			FindObjectOfType<TopCameraFollow>().shouldShake = true;

			Destroy(this.gameObject);
			PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab,transform.position, Quaternion.identity);

		}

		if (col.gameObject.tag == "Building" || col.gameObject.tag == "StartZone")
		{
			PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab, transform.position, Quaternion.identity);
			Vector3 randomSpawnPos = new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area));
			transform.position = randomSpawnPos;
		}

	}
	
}
