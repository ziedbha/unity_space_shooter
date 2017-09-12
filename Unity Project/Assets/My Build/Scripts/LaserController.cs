using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public float duration;
	private Transform shotSpawn;

	// Use this for initialization
	void Start () {
		this.tag = "OneOnlyLaser";
		GameObject[] lasers = GameObject.FindGameObjectsWithTag("OneOnlyLaser");
		if (lasers.Length > 1) {
			for (int i = 0; i < lasers.Length - 1; i++) {
				Destroy (lasers [i]);	
			}
		}
		GameObject shotSpawnObject = GameObject.FindWithTag("LaserSpawn");
		if (shotSpawnObject != null) {
			shotSpawn = shotSpawnObject.GetComponent<Transform> ();
		} else {
			Destroy (gameObject);
			return;
		}
	}

	void Update() {
		if (Input.GetButton("Fire2") && (duration != 0)) {
			duration -= 1;
			StretchUp ();
		} else {
			StretchDown ();
		}
		if (shotSpawn == null) {
			Destroy (gameObject);
			return;
		}
		gameObject.transform.position = shotSpawn.position;
		if (duration == 0) {
			Destroy (gameObject);
		}

	}
		
	public void Activate() {
		Instantiate (gameObject);
	}

	void StretchUp() {
		if (this.transform.localScale.Equals(new Vector3(0,0,0))) {
			this.transform.localScale += new Vector3 (0.9f, 0.0f, 0.01f);
		} else if (this.transform.localScale.z <= 0.6f) {
			transform.localScale += new Vector3(0, 0, 0.03f);
		}
	}

	void StretchDown() {
		if (this.transform.localScale.z >= 0.0f) {
			transform.localScale -= new Vector3(0, 0, 0.06f);
		} else {
			transform.localScale = new Vector3(0, 0, 0);
		}	
	}
}
