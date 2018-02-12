using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float damage;

	// Use this for initialization
	void Start () {
		damage = 10;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			gameObject.SetActive (false);
		}
	}
}
