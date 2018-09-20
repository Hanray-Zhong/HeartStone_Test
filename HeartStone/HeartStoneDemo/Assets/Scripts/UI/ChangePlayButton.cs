using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayButton : MonoBehaviour {

	public float speed;
	public Image texture;
	private Color buttonColor;
	private bool canChange = false;

	void Start () {
	 	buttonColor = texture.color;
	}
	
	void Update () {
		if (buttonColor.a < 255 && canChange) {
			buttonColor.a += speed;
			texture.color = buttonColor;
		}
	}

	public void StartChange() {
		canChange = true;
	}


}
