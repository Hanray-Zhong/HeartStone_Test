using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero2Crystal : MonoBehaviour {

	public int maxNumber = 0;
	public int remainNumber = 0;
	public Text CrystalNumber;

	void Start () {
		
	}
	
	void Update () {
		maxNumber = PlayerPrefs.GetInt("Hero2_MaxCrystal");
		UpdateShow();
	}

	public void UpdateShow() {
		CrystalNumber.text = remainNumber + "/" + maxNumber;
	}
}
