using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	private Vector3 spin;
	public float spinValue;
	// Update is called once per frame
	void LateUpdate () {
		spin += new Vector3 (0, spinValue, 0);
		transform.eulerAngles += spin;
	}
}
