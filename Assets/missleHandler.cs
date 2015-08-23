using UnityEngine;
using System.Collections;

public class missleHandler : MonoBehaviour {

	public GameObject player;
	public float speed;

	private Vector3 dist = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		dist = player.transform.position - transform.position;
		dist = dist.normalized;
		GetComponent<Rigidbody> ().AddForce (dist * speed);
	}
}
