using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour {

	public GameObject explosionPrefab;
	public GameObject gameOverUIPrefab;

	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("nukeTouchdown")) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			GameObject.Instantiate (gameOverUIPrefab, Vector3.zero, Quaternion.identity);
			GameObject.Destroy (gameObject.transform.parent.gameObject);
		} else {
			Debug.Log ("Nuke collided with " + other.name);
		}
	}
}
