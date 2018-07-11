using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

	public virtual void OnObjectReuse ()
	{

	}

	protected void Destroy (GameObject whatToDestroy)
	{
		//gameObject.SetActive(false);
		whatToDestroy.SetActive(false);
	}
}
