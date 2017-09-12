using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePickup : MonoBehaviour {

	public GameObject powerUp;
	private Transform player;

	void Start() {
		GameObject playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null) {
			player = playerObject.GetComponent<Transform> ();
		} else {
			Debug.Log ("Cannot find Player Transform!");
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			switch (powerUp.tag) {
			case "Shield":
				GameObject powerInstance = Instantiate(powerUp, player.transform.position, player.transform.rotation);
				powerInstance.transform.parent = player;
				powerInstance.tag = "OneOnlyShield";
				GameObject[] shields = GameObject.FindGameObjectsWithTag("OneOnlyShield");
				if (shields.Length > 1) {
					for (int i = 0; i < shields.Length - 1; i++) {
						Destroy (shields [i]);	
					}
				}
				break;
			case "Laser":
				powerUp.GetComponent<LaserController> ().Activate();
				break;
			}
			Destroy (gameObject);
		} else {
			return;
		}
	}
}
