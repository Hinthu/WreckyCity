using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverExplosionEffect : PoolObject {

	public ParticleSystem myParticleSystem;

	public override void OnObjectReuse()
	{
		myParticleSystem = this.gameObject.GetComponent<ParticleSystem>();
		myParticleSystem.Clear();
		myParticleSystem.Play();

	}
}
