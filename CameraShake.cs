using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

	public Camera mainCam;

	public float shakeAmount = 0;

	void Awake()
	{
		if (mainCam == null)
			mainCam = Camera.main;
	}

	public void Shake(float amt, float length)
	{
		shakeAmount = amt;
		InvokeRepeating("DoShake", 0, 0.01f);
		Invoke("StopShake", length);
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			Shake(0.1f, 0.2f);
		}
	}

	void DoShake()
	{
		if (shakeAmount > 0)
		{
			Vector3 camPos = mainCam.transform.position;

			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetZ = Random.value * shakeAmount * 2 - shakeAmount;
			camPos.x += offsetX;
			camPos.y += offsetY;
			camPos.z += offsetZ;

			mainCam.transform.position = camPos;
		}
	}

	void StopShake()
	{
		CancelInvoke("DoShake");
		mainCam.transform.localPosition = Vector3.zero;
	}

}
