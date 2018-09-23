using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardMind {
	Ovens,
	Magic,
	Weapon,
}

public enum Hand {
	player1,
	player2,
}

public class CardUnit : MonoBehaviour {
	public int hp;
	public int attack;
	public int crystalCost;
	public CardMind cardMind;
	public Hand hand;

	public Text hpLabel;
	public Text attackLabel;

	public void ResetShow() {
		hpLabel.text = hp.ToString();
		attackLabel.text = attack.ToString();
	}
}
