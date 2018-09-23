using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecideHero : MonoBehaviour {

	public int maxHP = 30;
	public int minHP = 0;

	public Sprite[] heros;
	public Text health_label;

	public int health = 30;

	void Start () {
		int heroIndex = PlayerPrefs.GetInt("Hero");
		gameObject.GetComponent<Image>().sprite = heros[heroIndex];
	}

	public void TakeDamage(int damage) {
		health -= damage;
		health_label.text = health.ToString();
		if (health < minHP) {
			// 处理游戏结束的逻辑
		}
	}

	public void PlusHealth(int hp) {
		if (health + hp <= 30) {
			health += hp;
		}	
		else {
			health = maxHP;
		}
		health_label.text = health.ToString();
	}
	
}
