using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public bool staticSpeed;
	public bool enemyShip;
	// Use this for initialization

	void Start () {
		if (!staticSpeed) {
			if (enemyShip) {
				speed = Random.Range (-5, -10);				
			} else {
				speed = Random.Range (-5, -30);
			}
		}
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
