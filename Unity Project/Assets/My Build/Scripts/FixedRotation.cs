using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour {

	private Vector3 fixedRotation;


	void Awake() {
		fixedRotation = new Vector3 (0,0,0);
	}

	void LateUpdate() {
		transform.eulerAngles = fixedRotation;
	}

}
