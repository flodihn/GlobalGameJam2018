using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject player;
	private Vector2 origPos;

	void Start() {
		origPos = transform.position;
	}

    void Update() {
		transform.position = new Vector3 (player.transform.position.x, origPos.y, player.transform.position.z);
    }
}
