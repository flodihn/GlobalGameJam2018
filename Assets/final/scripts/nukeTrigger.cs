using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nukeTrigger : MonoBehaviour {

	public Slider kimSlider;
	public GameObject nukePrefab;

    public Sprite[] kimfaces;

    public GameObject kimPortrait;

	public void nukeCHange() {
		if (kimSlider.value == kimSlider.maxValue) {
		print ("Kim has value " + kimSlider.value);
			GameObject.Instantiate (nukePrefab, Vector3.zero, Quaternion.identity);
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
