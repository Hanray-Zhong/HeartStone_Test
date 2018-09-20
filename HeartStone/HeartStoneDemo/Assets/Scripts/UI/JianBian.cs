using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JianBian : MonoBehaviour {

	private CanvasGroup canvasGroup;

	public float changeSpeed;

	void Start () {
		canvasGroup = gameObject.GetComponent<CanvasGroup>();
	}

	void Update () {
		if (canvasGroup.alpha < 1)
			canvasGroup.alpha += changeSpeed * Time.deltaTime;
	}

	public void close() {
		canvasGroup.alpha = 0;
	}

}