using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nukeTrigger : MonoBehaviour {

	public Slider kimSlider;
	public GameObject nukePrefab;

    public Sprite[] kimfaces;

    public int SceneToLoad = 3;

    public GameObject kimPortrait;

    public Text tweetsDestroyedText;

    public GameObject GameOverText;

    public IEnumerator GameOverNumerator() {
        GameOverText.SetActive(true);
        foreach(RadioWaveLauncher tower in FindObjectsOfType<RadioWaveLauncher>()) {
            tower.enabled = false;
        }
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(SceneToLoad);

    }

	public void nukeCHange() {
		if (kimSlider.value == kimSlider.maxValue) {
		print ("Kim has value " + kimSlider.value);
			GameObject.Instantiate (nukePrefab, Vector3.zero, Quaternion.identity);
            StartCoroutine(GameOverNumerator());
		}
        else if(kimSlider.value > 32 &&  kimSlider.value < 66) {
            print("Dasdas");
            kimPortrait.GetComponent<Image>().sprite = kimfaces[1];
        }
        else if (kimSlider.value  > 66) {
            print("Dasdas");
            kimPortrait.GetComponent<Image>().sprite = kimfaces[2];
        }

    }


}
