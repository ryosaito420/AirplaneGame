using UnityEngine;
using System.Collections;

public class moveRing : MonoBehaviour {

	public float thrust;
	public Transform plane;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * -thrust * Time.deltaTime);
		Vector3 dist = plane.position - transform.position; 
		dist = dist.normalized;

		if (dist.x > 10) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		thrust += 10;

		//Increase missle distance here
	}

}
