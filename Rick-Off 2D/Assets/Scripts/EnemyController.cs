using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	public float speed, enemyHealth;
	public Animator anim;
	public bool isDead;
	public AudioSource ohmanAudio, ohmygodAudio, mymanAudio;

	private Rigidbody2D rb2d;
	private Vector2 direction;
	private string lastTriggerSet;
	private GameObject manager;
	private EnemyManager managerScript;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		manager = GameObject.Find ("Morty Spawn Location");
		managerScript = manager.GetComponent<EnemyManager>();
		speed = 10;
		enemyHealth = 100;
		direction = Vector2.up;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * Time.deltaTime);

		if (enemyHealth <= 0) { //success killing enemy!
			managerScript.killCount += 1;
			ohmygodAudio.Play ();

			Debug.Log("you have killed enemy: SUCCESS");
			DestroySelf();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Bullet")) {
			enemyHealth -= 10;
			ohmanAudio.Play ();
		} else if (other.gameObject.CompareTag ("Right Turn Trigger")) {
			anim.ResetTrigger (lastTriggerSet);
			anim.SetTrigger ("Turn Right");
			direction = Vector2.left;
			lastTriggerSet = "Turn Right";
		} else if (other.gameObject.CompareTag ("Left Turn Trigger")) {
			anim.ResetTrigger (lastTriggerSet);
			anim.SetTrigger ("Turn Left");
			direction = Vector2.right;
			lastTriggerSet = "Turn Left";
		} else if (other.gameObject.CompareTag ("Front Turn Trigger")) {
			anim.ResetTrigger (lastTriggerSet);
			anim.SetTrigger ("Face Forward");
			direction = Vector2.down;
			lastTriggerSet = "Face Forward";
		} else if (other.gameObject.CompareTag ("Back Turn Trigger")) {
			anim.ResetTrigger (lastTriggerSet);
			anim.SetTrigger ("Face Backward");
			direction = Vector2.up;
			lastTriggerSet = "Face Backward";
		} else if (other.gameObject.CompareTag ("End Path Trigger")) { //failure killing enemy!
			mymanAudio.Play();
			anim.SetTrigger ("End Path");
			managerScript.playerHealth -= 1;
			Debug.Log ("enemy has reached goal: FAILURE");
			DestroySelf();
		}
	}

	void DestroySelf() {
		managerScript.deadEnemy = gameObject;
		isDead = true;
	}
}