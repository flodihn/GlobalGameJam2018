using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonPlayer : MonoBehaviour {
	public GameObject gravitatorRoot;

	private Gravitator[] allGravitarors;
	private Rigidbody myRigidBody;
	public float forceMultiplier = 0.1f;
	public float speed;
	public float gravitationDrag = 0.0f;

	public void Start() {
		allGravitarors = gravitatorRoot.GetComponentsInChildren<Gravitator> ();
		myRigidBody = GetComponent<Rigidbody> ();

	}

	public void FixedUpdate() {
		gravitationDrag = 0.0f;


		for (int i = 0; i < allGravitarors.Length; i++) {
			Gravitator gravitator = allGravitarors [i];
			ApplyGravity (gravitator);
		}

		speed = myRigidBody.velocity.magnitude;
		myRigidBody.AddRelativeForce (Vector3.forward * Time.fixedDeltaTime * gravitationDrag * forceMultiplier, ForceMode.Impulse);

	}


	private void ApplyGravity(Gravitator gravitator) {
		
		float gravitatorDistance = Vector3.Distance (gravitator.transform.position, transform.position);
		float gravitatorMultiplier = gravitator.strength / gravitatorDistance;
		Vector3 gravitatorDir = gravitator.transform.position - transform.position;

		float rotatationSpeed = gravitatorMultiplier * gravitatorMultiplier * gravitatorMultiplier;

		Vector3 inverseVect = transform.InverseTransformPoint(gravitator.transform.position);
		float rotationAngle = Mathf.Atan2(inverseVect.x,inverseVect.z) * Mathf.Rad2Deg;
		Vector3 rotationVelocity = (Vector3.up * rotationAngle); 
		Vector3 deltavel = (rotationVelocity - myRigidBody.angularVelocity); 
		myRigidBody.AddTorque(deltavel * rotatationSpeed, ForceMode.Impulse);

		gravitationDrag += gravitatorMultiplier;
	}
}
