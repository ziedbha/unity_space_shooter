using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		GameObject[] controllers = GameObject.FindGameObjectsWithTag ("BGMusic");
		if (controllers.Length >= 1 ) {
			for(int i = 1; i < controllers.Length; i++){
				Destroy(controllers[i]);
			}
		} else {
			this.GetComponent<AudioSource>().Play ();
		}
		
	}
}
