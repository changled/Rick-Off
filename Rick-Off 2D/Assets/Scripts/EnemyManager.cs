using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	public float spawnTime = 3f;
	public Text healthText;
	public int numEnemies, playerHealth, killCount;
	public GameObject enemy, winText, loseText, restartText, deadEnemy, winMorty;
	public AudioSource goodjobAudio;

	private int spawnedCount;
	private bool restart;
	private GameObject instance;
//	private GameObject[] enemyArr = new GameObject[10];

	// Use this for initialization
	void Start () {
		winText = GameObject.Find ("winText");
		loseText = GameObject.Find ("gameoverText");
		playerHealth = 5;
		numEnemies = 10;
		killCount = spawnedCount = 0;
		restart = false;

		winText.SetActive (false);
		loseText.SetActive (false);
		restartText.SetActive (false);
		winMorty.SetActive (false);

		if (playerHealth > 0) {
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
		}
	}

	void Update() {
		if (deadEnemy != null) {
			Debug.Log ("(manager): A deadEnemy destroyed");
			Destroy (deadEnemy);
		}

		if (restart) {
			restartText.SetActive (true);
			RestartOption ();
		} else {
			if (playerHealth <= 0) { //player loses
				loseText.SetActive (true);
				restart = true;
			} else if (killCount >= numEnemies) { //player wins
				winText.SetActive (true);
				winMorty.SetActive (true);
				goodjobAudio.Play ();
				restart = true;
			} else {
				//			healthText.text = (numEnemies - spawnedCount) + " more Morty's to go!\nHealth: " + playerHealth;
				healthText.text = "Health: " + playerHealth;
			}
		}
	}

	void Spawn() {
		if (playerHealth <= 0 || killCount >= numEnemies) {
			return;
		}

		GameObject newEnemy = enemy;

		if (enemy == null) {
			Debug.Log ("enemy is null");
		} else {
			Debug.Log ("(manager): Enemy spawned");
			instance = Instantiate (newEnemy, transform.position, transform.rotation);
			spawnedCount += 1;
		}
	}

	void RestartOption () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
