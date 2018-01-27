using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotator : MonoBehaviour {

	public float rotateSpeed = 1;

	void Update () {
		transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);	
	}
}
