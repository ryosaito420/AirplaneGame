using UnityEngine;
using System.Collections;


//Scrolling background sprite and create new tile instance every ___ 
public class scrollBG : MonoBehaviour {

	public float velocity;
	public GameObject spawner;
	// Use this for initialization
	void Start () {
		 
	}

	void OnBecameInvisible() {
		//spawner.GetComponent<spawnBG> ().spawnNew = true; 
		spawnBG.spawnNew = true;
		spawnBG.dissapearDist = transform.position.y;

		Debug.Log(spawnBG.dissapearDist);
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * -velocity * Time.deltaTime);
	}
}



