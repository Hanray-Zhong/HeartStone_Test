using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardMove : EventTrigger {

    public GameObject[] heros;

    private void Awake() {
        
    }

    private void Update() {

    }

	public void Up(float yOffset) {
        gameObject.transform.Translate( Vector3.up * yOffset * Time.deltaTime, Space.World);
    }

	public void Down(float yOffset) {
        gameObject.transform.Translate( -Vector3.up * yOffset * Time.deltaTime, Space.World);
    }

    public void FollowMouesPoint() {
        gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
    }

    public void BackToOriPos() {
        if (gameObject.GetComponent<CardUnit>().hand == Hand.player1 && GetSpaceRect(GameObject.Find("CardSpace1").GetComponent<RectTransform>()).Contains(Input.mousePosition)) {
            if (GameObject.Find("Hero1Crystal").GetComponent<Hero1Crystal>().remainNumber >= gameObject.GetComponent<CardUnit>().crystalCost) {
                GameObject.Find("DeckController1").GetComponent<DeckController1>().putCard_1(gameObject);
                if (gameObject.GetComponent<CardUnit>().cardMind == CardMind.Ovens) {
                    GameObject.Find("CardSpace1").GetComponent<CardSpace1>().AddCard(gameObject);
                }
                else if (gameObject.GetComponent<CardUnit>().cardMind == CardMind.Magic) {
                    // 法术牌效果
                }
                else {
                    // 武器
                }
                GameObject.Find("Hero1Crystal").GetComponent<Hero1Crystal>().remainNumber -= gameObject.GetComponent<CardUnit>().crystalCost;
                return;
            }
            else {
                Debug.Log("我没有足够的法力值");
            }
        }
        if (gameObject.GetComponent<CardUnit>().hand == Hand.player2 && GetSpaceRect(GameObject.Find("CardSpace2").GetComponent<RectTransform>()).Contains(Input.mousePosition)) {
            if (GameObject.Find("Hero2Crystal").GetComponent<Hero2Crystal>().remainNumber >= gameObject.GetComponent<CardUnit>().crystalCost) {
                GameObject.Find("DeckController2").GetComponent<DeckController2>().putCard_2(gameObject);
                if (gameObject.GetComponent<CardUnit>().cardMind == CardMind.Ovens) {
                    GameObject.Find("CardSpace2").GetComponent<CardSpace2>().AddCard(gameObject);
                }
                else if (gameObject.GetComponent<CardUnit>().cardMind == CardMind.Magic) {
                    // 法术牌效果
                }
                else {
                    // 武器
                }
                GameObject.Find("Hero2Crystal").GetComponent<Hero2Crystal>().remainNumber -= gameObject.GetComponent<CardUnit>().crystalCost;
                return;
            }
            else {
                Debug.Log("我没有足够的法力值");
            }
        }
        GameObject.Find("DeckController1").GetComponent<DeckController1>().SortCards();
        GameObject.Find("DeckController2").GetComponent<DeckController2>().SortCards();
    }



    private Rect GetSpaceRect(RectTransform rect)
    {
	    Rect spaceRect = rect.rect;
	    Vector3 spacePos = rect.position;
	    spaceRect.x = spaceRect.x * rect.lossyScale.x + spacePos.x;
	    spaceRect.y = spaceRect.y * rect.lossyScale.y + spacePos.y;
	    spaceRect.width = spaceRect.width * rect.lossyScale.x;
	    spaceRect.height = spaceRect.height * rect.lossyScale.y;
	    return spaceRect;
    }

}
