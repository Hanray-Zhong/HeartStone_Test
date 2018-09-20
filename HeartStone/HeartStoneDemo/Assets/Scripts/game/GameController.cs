using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class GameController : MonoBehaviour {

	public List<GameObject> Deck;
	public List<GameObject> CardsInHand;
	public Transform FromPosition;
	public Transform ToPosition;
	public Transform ToPosition2;
	public Transform DestroyPosition;

	private System.Random rm = new System.Random();
	private GameObject cardPrefab;
	private float xOffset;

	void Start() {
		PlayerPrefs.SetInt("CardNumberInHand", 0);
		PlayerPrefs.SetInt("RemainCardNum", 30);
		xOffset = ToPosition2.position.x - ToPosition.position.x;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RandomGenerateCard();
		}
		if (Input.GetKeyDown(KeyCode.Delete)) {
			putCard(2);
		} 
		
	}

	public void RandomGenerateCard() {
		if (PlayerPrefs.GetInt("RemainCardNum") > 0 && PlayerPrefs.GetInt("CardNumberInHand") < 10) {
			GetNewRandomCard();	
			GameObject newCard = Instantiate(cardPrefab, FromPosition);
			Tweener tweener = newCard.transform.DOMove(ToPosition.position + new Vector3(xOffset, 0, 0) * CardsInHand.Count, 0.5f, true);
			tweener.SetEase(Ease.Linear);
			PlayerPrefs.SetInt("CardNumberInHand", PlayerPrefs.GetInt("CardNumberInHand") + 1);
			PlayerPrefs.SetInt("RemainCardNum", PlayerPrefs.GetInt("RemainCardNum") - 1);
			CardsInHand.Add(newCard);
		}
		else if (PlayerPrefs.GetInt("RemainCardNum") == 0) {
			Debug.Log("我已经没有卡牌了~");
		}
		else{
			GetNewRandomCard();
			GameObject newCard = Instantiate(cardPrefab, FromPosition);
			Tweener tweener = newCard.transform.DOMove(DestroyPosition.position, 0.5f, true);
			tweener.SetEase(Ease.Linear);
			Destroy(newCard, 1f);
			Debug.Log("我的手牌满了~");
			PlayerPrefs.SetInt("RemainCardNum", PlayerPrefs.GetInt("RemainCardNum") - 1);
		}
	}
		

	private void GetNewRandomCard() {
		int i = rm.Next(Deck.Count);
		cardPrefab = Deck[i];
		while(cardPrefab == null && PlayerPrefs.GetInt("RemainCardNum") != 0) {
			i = rm.Next(Deck.Count);
			cardPrefab = Deck[i];
		}
		Deck.RemoveAt(i);
	}

	private void putCard(int index) {
		if (CardsInHand[index] != null) {
			GameObject card = CardsInHand[index];
			CardsInHand.RemoveAt(index);
			Destroy(card);
			PlayerPrefs.SetInt("CardNumberInHand", PlayerPrefs.GetInt("CardNumberInHand") - 1);
		}
		SortCards();
	}

	private void SortCards() {
		for (int i = 0; i < CardsInHand.Count; i++) {
			CardsInHand[i].transform.position = ToPosition.transform.position + new Vector3(xOffset, 0, 0) * i;
		}
	}
}
