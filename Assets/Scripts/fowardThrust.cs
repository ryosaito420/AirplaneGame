using UnityEngine;
using System.Collections;

public class fowardThrust : MonoBehaviour {
	private Rigidbody rb;
	float thrust = 10;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (transform.right * thrust * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		thrust += 2;
		Destroy (other.gameObject);
	}

}
