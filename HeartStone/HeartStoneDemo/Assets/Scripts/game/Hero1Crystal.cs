using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero1Crystal : MonoBehaviour {

	public int maxNumber = 0;
	public int remainNumber = 0;
	public Text CrystalNumber;

	public GameObject[] Crystals;
	public Sprite[] CrystalsPicture;

	void Start () {
		
	}
	
	void Update () {
		maxNumber = PlayerPrefs.GetInt("Hero1_MaxCrystal");
		UpdateShow();
	}

	public void UpdateShow() {
		for (int i = maxNumber; i < 10; i++) {
			if (Crystals[i] != null)
				Crystals[i].SetActive(false);
		}
		for (int i = 0; i < maxNumber; i++) {
			if (Crystals[i] != null)
				Crystals[i].SetActive(true);
		}
		for (int i = remainNumber; i < maxNumber; i++) {
			if (Crystals[i] != null)
				Crystals[i].GetComponent<Image>().sprite = CrystalsPicture[0];
		}
		for (int i = 0; i < remainNumber; i++) {
			if (Crystals[i] != null)
				Crystals[i].GetComponent<Image>().sprite = CrystalsPicture[i + 1];
		}
		CrystalNumber.text = remainNumber + "/" + maxNumber;

	}

}
