using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour {
	public float speed;
	public Text axisText;
	private Rigidbody2D tankHeadRB;
	public GameObject tankHead;
//	public float fireRate = 0;
//	public float damage = 10;
//	public LayerMask notToHit;
//	private float timeToFire = 0;
//	private Transform firePoint;

//	void Awake() {
//		firePoint = transform.Find ("FirePoint");
//
//		if (firePoint == null) {
//			Debug.LogError ("No firepoint!");
//		}
//	}

	void Start() {
		tankHeadRB = tankHead.GetComponent<Rigidbody2D>();
		speed = 50;
		axisText.text = "on start";
	}

//	void Update() {
//		if (fireRate == 0) {
//			if (Input.GetButtonDown ("Fire1")) {
//				Shoot ();
//			}
//		} //if holding down fire button
//		else if(Input.GetButton("Fire1") && Time.time > timeToFire) {
//			timeToFire = Time.time + 1 / fireRate;
//			Shoot ();
//		}
//	}

	void FixedUpdate() {
		float turnAmount = Input.GetAxis ("Horizontal");
		tankHeadRB.MoveRotation (tankHeadRB.rotation - turnAmount * speed * Time.fixedDeltaTime);

		axisText.text = "current rotation: " + tankHeadRB.rotation.ToString() + "\nhorizontal turn amount: " + turnAmount.ToString ();
	}

	void Shoot() {
		Debug.LogError ("Fire!");
	}
}