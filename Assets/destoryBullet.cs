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

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "enemy") {
			Destroy (this.gameObject);
		}
	}
}
