using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class KimFace : MonoBehaviour {

	public Image portrait;
	public Slider kimSlider;

	public Sprite kimOK;
	public Sprite kimAnnoyed;
	public Sprite kimAngry;

	void Update () {
		float percentAngry = kimSlider.value / kimSlider.maxValue;

		if (percentAngry >= 0.66f) {
			portrait.sprite = kimAngry;
			return;
		}

		if (percentAngry >= 0.33f) {
			portrait.sprite = kimAnnoyed;
		} else {
			portrait.sprite = kimOK;
		}
	}
}
