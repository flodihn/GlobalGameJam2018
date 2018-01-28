using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinRadioWaveCollider : MonoBehaviour {
    public GameObject explosion;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "TrumpTransmission") {
            print("adadas");
            Instantiate(explosion, transform.position, Quaternion.identity);
            FindObjectOfType<DolphinShoot>().destroyedTrumpTweets++;
            FindObjectOfType<nukeTrigger>().tweetsDestroyedText.text = FindObjectOfType<DolphinShoot>().destroyedTrumpTweets.ToString();
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

}
