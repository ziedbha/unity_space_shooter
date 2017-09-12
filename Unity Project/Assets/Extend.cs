using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {
	
	public void StretchUp () {
		if (this.transform.localScale.Equals(new Vector3(0,0,0))) {
			this.transform.localScale += new Vector3 (0.9f, 0.0f, 1);
		} else if (this.transform.localScale.z <= 0.6f) {
			transform.localScale += new Vector3(0, 0, 0.03f);
		}
	}

	public void StretchDown () {
		if (this.transform.localScale.z >= 0.0f) {
			transform.localScale -= new Vector3(0, 0, 0.03f);
		} else {
			transform.localScale = new Vector3(0, 0, 0);
		}		
	}
}
