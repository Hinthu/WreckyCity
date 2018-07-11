using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngnoreColl : MonoBehaviour {

	public GameObject wreckingBall;

	void Start ()
	{
		wreckingBall = GameObject.FindGameObjectWithTag("WB");
		Physics.IgnoreCollision(GetComponent<Collider>(), wreckingBall.GetComponent<Collider>());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
