using UnityEngine;
using System.Collections;

public class fowardThrust : MonoBehaviour {
	private Rigidbody rb;
	public float thrust;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (transform.right * thrust * Time.deltaTime);
	}
}
