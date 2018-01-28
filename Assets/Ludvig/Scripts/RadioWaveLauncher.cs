using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWaveLauncher : MonoBehaviour {

    public float timeBetweenWaves;

    float timeSinceLastWave;

    public GameObject trumpRadioWave;

    Rigidbody ball;
    public Transform[] kimTowers;

    public float h = 25;
    public float gravity = -18;


    public void Start() {

        kimTowers = new Transform[GameObject.FindGameObjectsWithTag("Kim radio tower").Length];
        for (int i = 0; i < kimTowers.Length; i++) {
            kimTowers[i] = GameObject.FindGameObjectsWithTag("Kim radio tower")[i].transform;
        }

        ball = trumpRadioWave.GetComponent<Rigidbody>();

        h = Random.Range(2, h);

        ball.useGravity = false;
        //Launch();
    }

    void Update() {
        timeSinceLastWave += Time.deltaTime;
        if (timeSinceLastWave > timeBetweenWaves) {
            timeSinceLastWave = 0;
            Launch();
        }
    }

    void Launch() {
        GameObject wave = Instantiate(trumpRadioWave, transform.position, Quaternion.identity);
        ball = wave.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchData().initialVelocity;
    }

    LaunchData CalculateLaunchData() {
        int randomValue = Random.Range(0, kimTowers.Length);
        float displacementY = kimTowers[randomValue].position.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(kimTowers[randomValue].position.x - ball.position.x, 0, kimTowers[randomValue].position.z - ball.position.z);
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    	struct LaunchData {
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData (Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}
		
	}
}
