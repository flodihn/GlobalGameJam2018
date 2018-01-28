using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLagWaveLauncher : MonoBehaviour {

	public float timeBetweenWaves;

	float timeSinceLastWave;

	public GameObject trumpRadioWave;

	public Transform[] kimTowers;

	public float h = 25;
	public float gravity = -18;


	public void Start() {
		timeBetweenWaves = Random.Range (1, timeBetweenWaves);

		kimTowers = new Transform[GameObject.FindGameObjectsWithTag("Kim radio tower").Length];
		for (int i = 0; i < kimTowers.Length; i++) {
			kimTowers[i] = GameObject.FindGameObjectsWithTag("Kim radio tower")[i].transform;
		}
	}

	void Update() {
		timeSinceLastWave += Time.deltaTime;
		if (timeSinceLastWave > timeBetweenWaves) {
			timeSinceLastWave = 0;
			Launch();
			timeBetweenWaves = Random.Range (1, timeBetweenWaves);
		}
	}

	void Launch() {
		GameObject wave = Instantiate(trumpRadioWave, transform.position, Quaternion.identity);
		Rigidbody2D bd = wave.GetComponent<Rigidbody2D>();
		bd.AddForce(new Vector3(
			Random.Range(50, 100),
			Random.Range(50, 100),
			0));
	}
}