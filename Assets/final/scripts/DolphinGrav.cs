using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinGrav : MonoBehaviour {
	public float power;
	Rigidbody2D myRigidBody;

	void Start() {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		float gravMultiplier = transform.position.y;

		myRigidBody.AddForce (new Vector3 (0, -gravMultiplier * power, 0));
	}
}
