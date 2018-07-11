using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour {

	public float acceleration;
	public float rotationRate;
	public float turnValue = /*1f;*/0.9928004f;

	//touch
	private float screenCenterX;

	public float turnRotationAngle;
	public float turnRotationSeekSpeed;

	private float rotationVelocity;
	private float groundAngleVelocity;

	Vector3 forwardForce;

	public bool testingCar = true;

	public bool Pc = true;

	public int turnState = 0;


	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		screenCenterX = Screen.width * 0.5f;
	}

	void Update ()
	{
		TurnState();

		TouchCheck();
		
	}

	void TouchCheck()
	{
		if (Input.touchCount == 0)
		{
			StopTurn();
		}// if there are any touches currently
		else if (Input.touchCount > 0)
		{
			// get the first one
			Touch firstTouch = Input.GetTouch(0);

			// if it began this frame
			if (firstTouch.phase == TouchPhase.Began)
			{
				if (firstTouch.position.x > screenCenterX)
				{
					// if the touch position is to the right of center
					// move right
					TurnRight();
				}
				else if (firstTouch.position.x < screenCenterX)
				{
					// if the touch position is to the left of center
					// move left
					TurnLeft();
				}
			}
		}
	}


	void FixedUpdate ()
	{
		/*print(Input.GetAxis("Horizontal"));
		print(Input.GetAxis("Vertical"));
		*/
		if (Physics.Raycast(transform.position, transform.up * -1, 3f))
		{
			rb.drag = 1;
			if(testingCar == true)
			{
				Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");

				forwardForce = forwardForce * Time.deltaTime * rb.mass;

				rb.AddForce(forwardForce);

			}
			else if(testingCar == false)
			{
				Vector3 forwardForce = transform.forward * acceleration * 1;

				forwardForce = forwardForce * Time.deltaTime * rb.mass;

				rb.AddForce(forwardForce);
			}

		}
		else
		{
			rb.drag = 0;
		}

		if(Pc)
		{
			Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis("Horizontal");

			turnTorque = turnTorque * Time.deltaTime * rb.mass;
			rb.AddTorque(turnTorque);

			Vector3 newRotation = transform.eulerAngles;
			newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
			newRotation.x = newRotation.normalized.x;
			transform.eulerAngles = newRotation;
		}

		


	}

	public void TurnLeft ()
	{
		turnState = -1;
		
	}

	void TurnState ()
	{
		//Left
		if (turnState == -1)
		{
			Vector3 turnTorque = Vector3.up * rotationRate * -turnValue;

			turnTorque = turnTorque * Time.deltaTime * rb.mass;
			rb.AddTorque(turnTorque);

			Vector3 newRotation = transform.eulerAngles;
			newRotation.z = Mathf.SmoothDampAngle(newRotation.z, -turnValue * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
			newRotation.x = newRotation.normalized.x;
			transform.eulerAngles = newRotation;
		}//Right
		else if (turnState == 1)
		{
			
			Vector3 turnTorque = Vector3.up * rotationRate * turnValue;

			turnTorque = turnTorque * Time.deltaTime * rb.mass;
			rb.AddTorque(turnTorque);

			Vector3 newRotation = transform.eulerAngles;
			newRotation.z = Mathf.SmoothDampAngle(newRotation.z, turnValue * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
			newRotation.x = newRotation.normalized.x;
			transform.eulerAngles = newRotation;
		}
		//Stop
		else if (turnState == 0)
		{
			
			Vector3 turnTorque = Vector3.up * rotationRate * 0;

			turnTorque = turnTorque * Time.deltaTime * rb.mass;
			rb.AddTorque(turnTorque);

			Vector3 newRotation = transform.eulerAngles;
			newRotation.z = Mathf.SmoothDampAngle(newRotation.z, 0 * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
			newRotation.x = newRotation.normalized.x;
			transform.eulerAngles = newRotation;
		}
	}

	public void TurnRight ()
	{
		turnState = 1;
	}

	public void StopTurn()
	{
		turnState = 0;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Building")
		{ 
			
			//col.gameObject.GetComponent<Destructible>().CrackObject();
			//Debug.Log("Game Over");

			

			FindObjectOfType<TopCameraFollow>().shouldShake = true;

			PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab, transform.position, Quaternion.identity);

			
		}
		else if (col.gameObject.tag == "missileLauncher")
		{


			FindObjectOfType<TopCameraFollow>().shouldShake = true;

			PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab, transform.position, Quaternion.identity);
		}
		else if (col.gameObject.tag == "Enemy")
		{
		}
		else if (col.gameObject.tag == "tree")
		{

			FindObjectOfType<TopCameraFollow>().shouldShake = true;

			PoolManager.instance.ReuseObject(FindObjectOfType<EveryPooler>().everyExplosionPrefab, transform.position, Quaternion.identity);
		}
	}
}
