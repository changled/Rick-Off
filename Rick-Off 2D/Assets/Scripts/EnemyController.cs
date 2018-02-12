using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb2d;
	public Text healthText;
	public float health;
	public Animator anim;
	Vector2 direction;
	private string lastTriggerSet;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		speed = 10;
		health = 100;
		direction = Vector2.up;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * Time.deltaTime);
		healthText.text = "Health: " + health;

		if(health <= 0)
			gameObject.SetActive (false);
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Bullet")) {
			health -= 10;
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
		} else if (other.gameObject.CompareTag ("End Path Trigger")) {
			anim.SetTrigger ("End Path");
			Destroy (gameObject);
		}
	}
}