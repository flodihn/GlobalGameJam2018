using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {
	public Color waveColor;
	public GameObject[] wavePrefabs;
	public float waveSpeed = 10.0f;
	public float lifetime = 5.0f;

	private GameObject[] waveInstances;
	private List<SpriteRenderer> spriteRenders = new List<SpriteRenderer>();
	private float timePassedSinceLastCreatedWave;
	private int waveCreateIndex = 0;
	private float offsetX = 0.0f;
	private float fadeOutDelta = 0.0f;
	private float currentLifetime = 0.0f;

	public void Start() {
		waveInstances = new GameObject[wavePrefabs.Length];
		fadeOutDelta = 1.0f / lifetime;
		currentLifetime = lifetime;
	}

	public void Update() {
		CreateNextWave ();
		MoveForward ();
		FadeOut ();
		DestroyWaveIfFadedOut ();
		DestroyWaveGeneratorIfReachedLifetime ();
	}

	private void CreateNextWave() {
		if (waveCreateIndex >= wavePrefabs.Length)
			return;


		timePassedSinceLastCreatedWave += Time.deltaTime;

		if (timePassedSinceLastCreatedWave > 0.5f) {
			GameObject waveInst = (GameObject) Instantiate(
				wavePrefabs[waveCreateIndex],
				transform.position,
				transform.rotation);
			waveInstances [waveCreateIndex] = waveInst;
			waveInst.transform.SetParent(transform);

			timePassedSinceLastCreatedWave = 0.0f;
			SpriteRenderer spriteRenderer = waveInst.GetComponent<SpriteRenderer> ();
			spriteRenderer.material.color = waveColor;
			spriteRenders.Add (spriteRenderer);
			currentLifetime = lifetime;
			waveCreateIndex++;
		}
	}

	private void MoveForward() {
		for (int i = 0; i < waveInstances.Length; i++) {
			GameObject wave = waveInstances [i];
			if (wave == null)
				continue;
			
			wave.transform.Translate (Vector3.right * Time.deltaTime * waveSpeed);
		}
	}

	private void FadeOut() {
		foreach (SpriteRenderer spriteRenderer in spriteRenders) {
			float newAlpha = spriteRenderer.color.a - Time.deltaTime * fadeOutDelta;
			spriteRenderer.color = new Color (
				spriteRenderer.color.r,
				spriteRenderer.color.g,
				spriteRenderer.color.b,
				newAlpha);
		}
	}

	private void DestroyWaveIfFadedOut() {
		List<SpriteRenderer> spriteRenderersToRemove = new List<SpriteRenderer> ();
		foreach (SpriteRenderer spriteRenderer in spriteRenders) {
			if (spriteRenderer == null)
				continue;
			
			if (spriteRenderer.color.a <= 0.0f) {
				spriteRenderersToRemove.Add (spriteRenderer);
			}
		}

		foreach (SpriteRenderer spriteRenderer in spriteRenderersToRemove) {
			spriteRenders.Remove (spriteRenderer);
			GameObject.Destroy (spriteRenderer.gameObject);
		}
	}

	private void DestroyWaveGeneratorIfReachedLifetime() {
		currentLifetime -= Time.deltaTime;
		if(currentLifetime < 0)
			Destroy(gameObject);
	}
}
