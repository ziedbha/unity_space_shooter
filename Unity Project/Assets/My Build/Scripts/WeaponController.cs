using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	private AudioSource audioSource;
	public float fireRate;
	public float nextFire;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", nextFire, fireRate);
		
	}

	void Fire() {
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}
}
