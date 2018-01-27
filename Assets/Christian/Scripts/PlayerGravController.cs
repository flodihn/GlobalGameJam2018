using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravController : MonoBehaviour {
	public float power = 10000.0f;
	public float forceMultiplier = 100.0f;
	Rigidbody myRigidBody;

	void Start() {
		myRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		if (Input.GetKey (KeyCode.W)) {
			myRigidBody.AddForce (Vector3.forward * forceMultiplier);
			AddPower (-forceMultiplier);
		}

		if (Input.GetKey (KeyCode.A)) {
			myRigidBody.AddForce (Vector3.left * forceMultiplier);
			AddPower (-forceMultiplier);
		}

		if (Input.GetKey (KeyCode.D)) {
			myRigidBody.AddForce (Vector3.right * forceMultiplier);
			AddPower (-forceMultiplier);
		}

		if (Input.GetKey (KeyCode.S)) {
			myRigidBody.AddForce (Vector3.back * forceMultiplier);
			AddPower (-forceMultiplier);
		}
	}

	public void AddPower(float amount) {
		power += amount;
	}
}
