using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	float currentY;

	// Use this for initialization
	void Start () {
		currentY = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () { 	
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y = currentY;
		gameObject.transform.position = newPosition;
		//Debug.Log (gameObject.transform.position.x);
		if (gameObject.transform.position.x <= -17.0) {
			currentY = (Random.value * 7) - 2;
		}
			
	
	}
}
