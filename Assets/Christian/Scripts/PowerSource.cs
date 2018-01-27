using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : MonoBehaviour {
	public float powerAmplifier = 10.0f;
	private GameObject player;
	private PlayerGravController playerGravController;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerGravController = player.GetComponent<PlayerGravController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(transform.position, player.transform.position);
		playerGravController.AddPower (distance * Time.deltaTime * powerAmplifier);

	}
}
