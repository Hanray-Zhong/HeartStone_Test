using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecideHero : MonoBehaviour {

	public Sprite[] heros;

	void Start () {
		int heroIndex = PlayerPrefs.GetInt("Hero");
		gameObject.GetComponent<Image>().sprite = heros[heroIndex];
	}
	
}
