using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinRadioWaveCollider : MonoBehaviour {
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other) {
        print("adadas");
        if(other.gameObject.tag == "TrumpTransmission") {
            print("adada");
            Instantiate(explosion, transform.position, Quaternion.identity);
            FindObjectOfType<DolphinShoot>().destroyedTrumpTweets++;

            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

}
