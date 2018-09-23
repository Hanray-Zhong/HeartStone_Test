using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndTurnButton : MonoBehaviour {

	public GameObject text1;
	public GameObject text2;
	public GameController controller;
	public DeckController1 deck1;
	public DeckController2 deck2;



	public GameObject Hero1Crystal;
	public GameObject Hero2Crystal;

	void Start() {
		PlayerPrefs.SetInt("Hero1_MaxCrystal", 1);
		PlayerPrefs.SetInt("Hero2_MaxCrystal", 0);
	}

	public void OnEndButtonClick() {
		controller.gameState = GameState.End;
		Debug.Log("回合结束");
		TransformPlayer();
	}

	private void TransformPlayer() {
		Debug.Log("回合开始");
		controller.gameState = GameState.CardGenerating;
		if (text1.activeSelf && !text2.activeSelf) {
			text1.gameObject.SetActive(false);
			text2.gameObject.SetActive(true);
			if (PlayerPrefs.GetInt("Hero2_MaxCrystal") < 10)
				PlayerPrefs.SetInt("Hero2_MaxCrystal", PlayerPrefs.GetInt("Hero2_MaxCrystal") + 1);
			else
				PlayerPrefs.SetInt("Hero2_MaxCrystal", 10);
			Hero2Crystal.GetComponent<Hero2Crystal>().remainNumber = PlayerPrefs.GetInt("Hero2_MaxCrystal");
			deck2.RandomGenerateCard_2();
			controller.gameState = GameState.PlayCard;
			Debug.Log("出牌阶段");
			return;
		}
		if (text2.activeSelf && !text1.activeSelf) {
			text2.gameObject.SetActive(false);
			text1.gameObject.SetActive(true);
			if (PlayerPrefs.GetInt("Hero1_MaxCrystal") < 10)
				PlayerPrefs.SetInt("Hero1_MaxCrystal", PlayerPrefs.GetInt("Hero1_MaxCrystal") + 1);
			else
				PlayerPrefs.SetInt("Hero1_MaxCrystal", 10);
			Hero1Crystal.GetComponent<Hero1Crystal>().remainNumber = PlayerPrefs.GetInt("Hero1_MaxCrystal");
			deck1.RandomGenerateCard_1();
			controller.gameState = GameState.PlayCard;
			Debug.Log("出牌阶段");
			return;
		}
	}
}
