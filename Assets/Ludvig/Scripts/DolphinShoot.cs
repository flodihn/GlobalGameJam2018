using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinShoot : MonoBehaviour {

    public int damage;
    public float attackSpeed;
    public float bulletSpeed = 5;

    public float bulletSize = 0.1f;

    public GameObject radioWavePrefab;

    GameObject radioWaveHolder;

    public AudioClip[] dolphinShoot;

    AudioSource audioSource;

    float timePassedSinceLastRadioWave;

    public float echouAttackFrequency = 0.1f;

    private void Start() {
        radioWaveHolder = new GameObject("radioWaveHolder");
        audioSource = GetComponent<AudioSource>();
    }
    void Update () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        timePassedSinceLastRadioWave += Time.deltaTime;
        if (Input.GetButton("Fire1") && timePassedSinceLastRadioWave > attackSpeed) {

            timePassedSinceLastRadioWave = 0;
            GameObject radioWave = Instantiate(radioWavePrefab, radioWaveHolder.transform, true);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            audioSource.clip = dolphinShoot[Random.Range(0, 2)];

            audioSource.Play();

            radioWave.transform.position = transform.position;

            radioWave.GetComponent<WaveGenerator>().waveSpeed += GetComponent<Rigidbody2D>().velocity.magnitude * 0.1f;

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            radioWave.transform.rotation = Quaternion.Euler(0f, 0f, rot_z );


            //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletSpeed);

            
        }		
	}
}
