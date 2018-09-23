using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DeckController1 : MonoBehaviour {

	public List<GameObject> Deck;
	public List<GameObject> CardsInHand;
	public Transform FromPosition;
	public Transform ToPosition;
	public Transform ToPosition2;
	public Transform DestroyPosition;

	private System.Random rm = new System.Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds + 5);
	private GameObject cardPrefab;
	private float xOffset;

	void Start() {
		xOffset = ToPosition2.position.x - ToPosition.position.x;
	}

	void Update() {
		
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			RandomGenerateCard_1();
			Debug.Log(PlayerPrefs.GetInt("CardNumberInHand_1"));
		}
	}

	public void RandomGenerateCard_1() {
		if (PlayerPrefs.GetInt("RemainCardNum_1") > 0 && PlayerPrefs.GetInt("CardNumberInHand_1") < 10) {
			GetNewRandomCard_1();	
			GameObject newCard = Instantiate(cardPrefab, FromPosition);
			newCard.GetComponent<CardUnit>().hand = Hand.player1;
			Tweener tweener = newCard.transform.DOMove(ToPosition.position + new Vector3(xOffset, 0, 0) * CardsInHand.Count, 0.5f, true);
			tweener.SetEase(Ease.Linear);
			PlayerPrefs.SetInt("CardNumberInHand_1", PlayerPrefs.GetInt("CardNumberInHand_1") + 1);
			PlayerPrefs.SetInt("RemainCardNum_1", PlayerPrefs.GetInt("RemainCardNum_1") - 1);
			CardsInHand.Add(newCard);
		}
		else if (PlayerPrefs.GetInt("RemainCardNum_1") == 0) {
			Debug.Log("我已经没有卡牌了~");
		}
		else{
			GetNewRandomCard_1();
			GameObject newCard = Instantiate(cardPrefab, FromPosition);
			newCard.GetComponent<CardUnit>().hand = Hand.player1;
			Tweener tweener = newCard.transform.DOMove(DestroyPosition.position, 0.5f, true);
			tweener.SetEase(Ease.Linear);
			Destroy(newCard, 1f);
			Debug.Log("我的手牌满了~");
			PlayerPrefs.SetInt("RemainCardNum_1", PlayerPrefs.GetInt("RemainCardNum_1") - 1);
		}
	}
		

	private void GetNewRandomCard_1() {
		int i = rm.Next(Deck.Count);
		cardPrefab = Deck[i];
		while(cardPrefab == null && PlayerPrefs.GetInt("RemainCardNum_1") != 0) {
			i = rm.Next(Deck.Count);
			cardPrefab = Deck[i];
		}
		Deck.RemoveAt(i);
	}


	public void putCard_1(GameObject put_card) {
		CardsInHand.Remove(put_card);
		PlayerPrefs.SetInt("CardNumberInHand_1", PlayerPrefs.GetInt("CardNumberInHand_1") - 1);
		SortCards();
	}


	/***************************common***************************/

	public void SortCards() {
		for (int i = 0; i < CardsInHand.Count; i++) {
			CardsInHand[i].transform.position = ToPosition.transform.position + new Vector3(xOffset, 0, 0) * i;
		}
	}
}
