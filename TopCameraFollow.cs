using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public float power = 0.7f;
	public float duration = 1f; 
	public Transform camera;
	public float slowDownAmount;
	public bool shouldShake = false;

	Vector3 startPosition;
	float initialDuration;
	
	
	// Use this for initialization
	void Start ()
	{
		camera = Camera.main.transform;
		
		initialDuration = duration;
	}

	void Update ()
	{


		CameraShake();
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
		

		transform.LookAt(target);
	}

	void CameraShake ()
	{
		startPosition = camera.localPosition;
		if (shouldShake)
		{
			if (duration > 0)
			{
				camera.localPosition = startPosition + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			}
			else
			{
				shouldShake = false;
				duration = initialDuration;
				camera.localPosition = startPosition;
			}
		}
	}
}
