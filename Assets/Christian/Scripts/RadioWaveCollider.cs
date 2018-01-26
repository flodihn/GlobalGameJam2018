using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWaveCollider : MonoBehaviour {

	private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent> ();
	public ParticleSystem myParticleSystem;

	void Start() {
		myParticleSystem = GetComponent<ParticleSystem> ();
	}

	public void OnParticleCollision(GameObject other) {
		ParticlePhysicsExtensions.GetCollisionEvents (myParticleSystem, other, collisionEvents);
		for (int i = 0; i < collisionEvents.Count; i++) {
			Debug.Log ("Particle collided with " + other.name);
		}
	}
}
