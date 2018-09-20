using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHero : MonoBehaviour {

	public Sprite[] heros;
	public string[] names;
	public GameObject picture;
	public Text heroName;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void ChangeHeroPicture(int i) {
		picture.GetComponent<Image>().sprite = heros[i];
		heroName.text = names[i].ToString();
		PlayerPrefs.SetInt("Hero", i);
	}

}
