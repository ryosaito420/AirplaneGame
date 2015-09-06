using UnityEngine;
using System.Collections;

public class fireLaser : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed;
	public float fireCD;

	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && timer <= 0) {
			GameObject new_bullet = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), bullet.transform.localRotation) as GameObject;
			Rigidbody2D clone = new_bullet.GetComponent<Rigidbody2D> ();
			clone.velocity = (transform.up * bulletSpeed);
			timer = fireCD;
			//new_bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
			//new_bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20f);
		} else
			timer--;
	}
}
