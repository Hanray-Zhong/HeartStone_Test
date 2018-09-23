using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject[] nodes;
	public GameObject hero;
	public GameObject ArrowHead;
	public GameObject node1;
	public GameObject node2;

	private float distance;
	private float yOffset;

	private void Start() {
		yOffset = Vector2.Distance(node1.transform.position, node2.transform.position);
	}

	private void Update() {
		UpdateDir();
		UpdateLenth();
	}

	private void UpdateDir() {
		gameObject.transform.up = Input.mousePosition - hero.transform.position;
	}

	private void UpdateLenth() {
		distance = Vector2.Distance(Input.mousePosition, hero.transform.position);
		int nodeNum = (int) (distance / yOffset);
		if (nodeNum >= nodes.Length)
			nodeNum = nodes.Length;
		if (nodeNum <= 0)
			nodeNum = 0;
		for (int i = 0; i < nodeNum - 2; i++) {
			nodes[i].gameObject.SetActive(true);
		}
		for (int i = nodeNum - 2; i < nodes.Length; i++) {
			nodes[i].gameObject.SetActive(false);
		}
		if (distance <= 19 * yOffset)
			ArrowHead.transform.position = Input.mousePosition;
	}

}
