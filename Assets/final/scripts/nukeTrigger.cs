using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nukeTrigger : MonoBehaviour {

	public Slider kimSlider;
	public GameObject nukePrefab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nukeCHange() {
		print ("works has value " + kimSlider.value);
		if (kimSlider.value == kimSlider.maxValue) {
			GameObject.Instantiate (nukePrefab, Vector3.zero, Quaternion.identity);
		}

	}


}
