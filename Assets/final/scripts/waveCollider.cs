using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveCollider : MonoBehaviour {

	Slider kimSlider;

	// Use this for initialization
	void Start () {
		kimSlider = GameObject.FindGameObjectWithTag ("kim_slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("YAY! " + other.name);
		if (other.tag.Equals ("Kim radio tower")) {
			Debug.Log ("Kims radio tower has received Trumps tweet! ");
			kimSlider.value += 3;
            Destroy(gameObject.transform.parent.gameObject);
		}
        else if(other.gameObject.name == "Player") {
            Instantiate(other.gameObject.GetComponent<DolphinShoot>().destroyedRadioWaveExplosion, transform.position, Quaternion.identity);
        }
        else {
			GameObject.Destroy (gameObject);
		}
	}
}
