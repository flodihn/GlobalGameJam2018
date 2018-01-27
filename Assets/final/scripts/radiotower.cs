using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiotower : MonoBehaviour {

	public GameObject WaveGeneratorPrefab;

	// Use this for initialization
	void Start () {
		sendRadioWave ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void sendRadioWave() {
		GameObject gejmObject = GameObject.Instantiate(WaveGeneratorPrefab, transform.position, Quaternion.identity);
	}
}
