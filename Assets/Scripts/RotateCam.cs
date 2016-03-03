using UnityEngine;
using System.Collections;

public class RotateCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.K)) {
			            Quaternion newRotation = this.transform.rotation;
			            Vector3 angles = newRotation.eulerAngles;
			            angles.z += 10;
			            newRotation.eulerAngles = angles;
			            this.transform.rotation = newRotation;
			        }

	}
	}
