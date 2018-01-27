using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinShoot : MonoBehaviour {

    public int damage;
    public float attackSpeed;
    public float bulletSpeed = 5;

    public GameObject radioWave;

    GameObject radioWaveHolder;

    public AudioClip[] dolphinShoot;

    AudioSource audioSource;

    private void Start() {
        radioWaveHolder = new GameObject("radioWaveHolder");
        audioSource = GetComponent<AudioSource>();
    }
    void Update () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1")) {
            GameObject bullet = Instantiate(radioWave, radioWaveHolder.transform, true);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            audioSource.clip = dolphinShoot[Random.Range(0, 2)];

            audioSource.Play();

            

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            bullet.transform.position = transform.position;

            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletSpeed);

        }		
	}
}
