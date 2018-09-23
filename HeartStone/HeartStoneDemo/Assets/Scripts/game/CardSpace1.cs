using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardSpace1 : MonoBehaviour {
    public List<GameObject> cardInTheSpace;

    public GameObject space1;
    public GameObject space2;

    private float xOffset = 0;
    Transform pos1;
    Transform pos2;

    private void Start() {
        pos1 = space1.GetComponent<Transform>();
        pos2 = space2.GetComponent<Transform>();
        xOffset = pos2.position.x - pos1.position.x;
    }

    public Vector3 SortCard() {
        int index = cardInTheSpace.Count;

        if (index % 2 == 0) {
            float myxOffset = (index / 2) * xOffset;
            Vector3 pos = new Vector3(pos1.position.x - myxOffset, pos1.position.y, pos1.position.z);
            return pos;
        }
        else {
            float myxOffset = (index / 2 - 1) * xOffset;
            Vector3 pos = new Vector3(pos2.position.x + myxOffset, pos2.position.y, pos2.position.z);
            return pos;
        }
    }

    public void AddCard(GameObject newCard) {
        cardInTheSpace.Add(newCard);
        Tweener tweener = newCard.transform.DOMove(SortCard(), 0.5f, true);
        tweener.SetEase(Ease.Linear);
    }
	
}
