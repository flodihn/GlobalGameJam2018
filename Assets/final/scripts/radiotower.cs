using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiotower : MonoBehaviour {

	public GameObject WaveGeneratorPrefab;
	public float timeBetweenWaves;

	float timeSinceLastWave;

	// Use this for initialization
	void Start () {
		timeSinceLastWave = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastWave += Time.deltaTime;
		if (timeSinceLastWave > timeBetweenWaves) {
			sendRadioWave ();
			timeSinceLastWave = 0;
		}
	}

	void sendRadioWave() {
		GameObject gejmObject = GameObject.Instantiate(WaveGeneratorPrefab, transform.position, Quaternion.identity);
	}
}
