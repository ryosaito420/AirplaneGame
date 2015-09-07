using UnityEngine;
using System.Collections;

public class destoryBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "enemy") {
			Destroy (this.gameObject);
		}
	}
}
