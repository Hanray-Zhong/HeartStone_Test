using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragArrow : EventTrigger {

	public void FollowMouesPoint() {
        gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
    }

	

	
}
