using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public GameObject black;

	public void loadLevel() {
		black.SetActive(true);
		StartCoroutine(LoadPlayScene());
	}

	IEnumerator LoadPlayScene() {
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(0);
	}


}
