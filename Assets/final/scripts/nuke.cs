using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuke : MonoBehaviour {

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("nukeTouchdown")) {
			GameObject.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			GameObject.Destroy (gameObject);
		} else {
			Debug.Log ("Nuke collided with " + other.name);
		}
	}
}
