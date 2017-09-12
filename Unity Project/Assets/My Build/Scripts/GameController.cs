using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public GameObject[] powerUps;
	public Vector3 spawnValues;
	private int hazardCount;
	public float spawnWait;
	public float startWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText ggText;
	private bool gg;
	private bool restart;
	private int score;



	// Use this for initialization
	void Start () {
		gg = false;
		restart = false;
		restartText.text = "";
		ggText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		
	}

	void Update() {
		if(restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene ("Main");
			}
		}
	}
	
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (!gg) {
			hazardCount = Random.Range (1, 15);
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				int random = Random.Range (5, 1000);
				if ((random % 11) == 0) {
					GameObject powerUp = powerUps [Random.Range (0, powerUps.Length)];
					Vector3 spawnPositionP = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotationP = Quaternion.identity;
					Instantiate (powerUp, spawnPositionP, spawnRotationP);
					yield return new WaitForSeconds (spawnWait);
				}
				Vector3 spawnPositionH = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotationH = Quaternion.identity;
				Instantiate (hazard, spawnPositionH, spawnRotationH);
				yield return new WaitForSeconds (spawnWait);
				if (gg) {
					restartText.text = "Press 'R' to \n Restart";
					restart = true;
					break;
				}
			}				
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	public void GG() {
		ggText.text = "Game Over!";
		gg = true;
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
