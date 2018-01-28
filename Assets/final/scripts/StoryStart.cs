using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryStart : MonoBehaviour {

	public int sceneNumber;


	public void loadScene() {
		SceneManager.LoadScene (sceneNumber);
	}
}
