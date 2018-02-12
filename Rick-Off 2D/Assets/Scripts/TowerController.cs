using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour {
	public float speed;
	private Rigidbody2D tankHeadRB;
	public GameObject tankHead;
	public GameObject bulletPrefab;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	public float fireRate = 5;
	public LayerMask whatToHit;
	private float timeToFire = 0;
	private Transform firePoint;
	private Vector2 firePointPosition;
	private Vector2 shootPoint1;
	private Vector2 shootPoint2;

	void Awake() {
		
		firePoint = transform.Find ("FirePoint");

		if (firePoint == null) {
			Debug.LogError ("No firepoint!");
		}
		//		Debug.DrawLine(firePointPosition, fireDirection * 10);
	}

	void Start() {
		tankHeadRB = tankHead.GetComponent<Rigidbody2D>();
		speed = 50;
	}

	void Update() {

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Fire();
			}
		} //if holding down fire button
		else if(Input.GetButton("Fire1") && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Fire();
		}
	}

	void FixedUpdate() {
		float turnAmount = Input.GetAxis ("Horizontal") * speed * Time.fixedDeltaTime;
		tankHeadRB.MoveRotation (tankHeadRB.rotation - turnAmount);

	}

	void Fire() {
		var bullet1 = (GameObject)Instantiate (bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
		var bullet2 = (GameObject)Instantiate (bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);
		Vector2 leftGunDir = bullet1.transform.position - tankHead.transform.position;
		Vector2 rightGunDir = bullet2.transform.position - tankHead.transform.position;
		bullet1.GetComponent<Rigidbody2D> ().velocity = (leftGunDir * 10);
		bullet2.GetComponent<Rigidbody2D> ().velocity = (rightGunDir * 10);

//		Debug.Log ("FIRE!");
		Destroy (bullet1, 2.0f); //destroy bullet ImageEffectAfterScale 2 seconds
		Destroy (bullet2, 2.0f); //destroy bullet ImageEffectAfterScale 2 seconds
	}

//	function OnBecameInvisible() {
//		Destroy(GameObject);
//	}
}