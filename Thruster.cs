using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
	public float thrusterStrength;
	public float thrusterDistance;
	public Transform[] thrusters;

	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		RaycastHit hit;

		foreach (Transform thruster in thrusters)
		{
			Vector3 downwardForce;
			float distancePrecentage;

			if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
			{
				distancePrecentage = 1 - (hit.distance / thrusterDistance);

				downwardForce = transform.up * thrusterStrength * distancePrecentage;

				downwardForce = downwardForce * Time.deltaTime * rb.mass;

				rb.AddForceAtPosition(downwardForce, thruster.position);
			}
		}
	}
}
