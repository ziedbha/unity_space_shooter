using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float tilt;
	[Range(1,15)]
	public float moveSpeed = 10f;
	public Boundary boundary;
	public GameObject shot;
	public GameObject laser;
	public Transform shotSpawn;
	public float fireRate = 1.0f;

	private float nextFire = 0f;


	void Update(){
		if (Input.GetButton("Fire1") && (Time.time > nextFire)) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
			nextFire = Time.time + fireRate;
		} 
	}


	void FixedUpdate(){
		Rigidbody rb = GetComponent<Rigidbody>();
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveH, 0.0f, moveV);
		rb.velocity = movement * moveSpeed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
		
}
