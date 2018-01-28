using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveCollider : MonoBehaviour {

	Slider kimSlider;

    AudioClip kimJongKunMad;

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
			//Debug.Log ("Kims radio tower has received Trumps tweet! ");
			kimSlider.value += 5;
            Destroy(gameObject);
            GetComponent<AudioSource>().clip = kimJongKunMad;
            GetComponent<AudioSource>().Play();
		}
        else if(other.gameObject.name == "Player") {
            FindObjectOfType<DolphinShoot>().destroyedTrumpTweets++;
            FindObjectOfType<nukeTrigger>().tweetsDestroyedText.text = FindObjectOfType<DolphinShoot>().destroyedTrumpTweets.ToString();
            Instantiate(other.gameObject.GetComponent<DolphinShoot>().destroyedRadioWaveExplosion, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
	}
}
