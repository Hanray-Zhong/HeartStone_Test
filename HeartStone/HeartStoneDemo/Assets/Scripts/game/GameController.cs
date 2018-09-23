using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	GameStart,
	CardGenerating,
	PlayCard,
	End,
}

public class GameController : MonoBehaviour {

	public GameState gameState = GameState.GameStart;
	public GameObject[] Heros;

	private string currentHeroName = "Hero1";

	private void Start() {
		PlayerPrefs.SetInt("CardNumberInHand_1", 0);
		PlayerPrefs.SetInt("RemainCardNum_1", 30);
		PlayerPrefs.SetInt("CardNumberInHand_2", 0);
		PlayerPrefs.SetInt("RemainCardNum_2", 30);
		StartCoroutine(GenerateCardForHero_1());
		StartCoroutine(GenerateCardForHero_2());
		gameState = GameState.CardGenerating;
		Debug.Log("回合开始");
	}
		

	private void Update() {
		if (gameState == GameState.CardGenerating) {
			StartCoroutine(StartTurn());
		}
		if (gameState == GameState.PlayCard) {

		}
		if (gameState == GameState.End) {
			StartCoroutine(EndTurn());
		}
	}


	private IEnumerator GenerateCardForHero_1() {
		Heros[0].GetComponent<DeckController1>().RandomGenerateCard_1();
		yield return new WaitForSeconds(0.5f);
		Heros[0].GetComponent<DeckController1>().RandomGenerateCard_1();
		yield return new WaitForSeconds(0.5f);
		Heros[0].GetComponent<DeckController1>().RandomGenerateCard_1();
		yield return new WaitForSeconds(0.5f);
	}
	private IEnumerator GenerateCardForHero_2() {
		Heros[1].GetComponent<DeckController2>().RandomGenerateCard_2();
		yield return new WaitForSeconds(0.5f);
		Heros[1].GetComponent<DeckController2>().RandomGenerateCard_2();
		yield return new WaitForSeconds(0.5f);
		Heros[1].GetComponent<DeckController2>().RandomGenerateCard_2();
		yield return new WaitForSeconds(0.5f);
		Heros[1].GetComponent<DeckController2>().RandomGenerateCard_2();
		yield return new WaitForSeconds(0.5f);
	}

	private IEnumerator StartTurn() {
		float waitTime = 5;
		yield return new WaitForSeconds(waitTime);
	}

	private IEnumerator EndTurn() {
		float waitTime = 5;
		yield return new WaitForSeconds(waitTime);
	}
	
}
