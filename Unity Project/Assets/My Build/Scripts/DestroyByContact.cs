using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find GameController Script!");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Pickup") || other.CompareTag("Boundary")) {
			return;
		}
		if (this.CompareTag("OneOnlyShield")) {
			if (!other.CompareTag("Friendly") && !other.CompareTag("Laser") && !other.CompareTag("OneOnlyLaser")) {
					DestroyCollided (other);
				}				
		} else {
			if (other.CompareTag("Enemy")) {
				return;
			}

			if (other.CompareTag("Player")) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GG ();
				DestroyCollided (other);

			} else {
				DestroyCollided (other);
				gameController.AddScore (scoreValue);		
			}						
		}

	}

	void DestroyCollided(Collider other) {
		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
		Destroy(gameObject);
		if (!other.CompareTag("OneOnlyLaser") && !other.CompareTag("Laser")) {
			Destroy(other.gameObject);
		}
	}
}
