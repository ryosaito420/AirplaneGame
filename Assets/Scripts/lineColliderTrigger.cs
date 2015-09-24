using UnityEngine;
using System.Collections;

public class lineColliderTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Line is created!");
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.tag == "enemy") {
			Debug.Log ("Enemy found!");
		}

	}


}
